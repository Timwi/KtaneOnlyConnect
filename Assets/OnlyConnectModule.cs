using System;
using System.Collections.Generic;
using System.Linq;
using OnlyConnect;
using UnityEngine;

using Rnd = UnityEngine.Random;

/// <summary>
/// On the Subject of Only Connect
/// Created by Timwi
/// </summary>
public class OnlyConnectModule : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMBombModule Module;
    public KMAudio Audio;

    public KMSelectable[] EgyptianHieroglyphButtons;
    public Material[] EgyptianHieroglyphs;
    public TextMesh TeamName;

    private static string[] _teams = {
        "PSMITHS",
        "COSMOPOLITANS",
        "SURREALISTS",
        "KORFBALLERS",
        "BEEKEEPERS",
        "OSCAR MEN",
        "FIRE-EATERS",
        "VERBIVORES",
        "GENEALOGISTS",
        "POLICY WONKS",
        "PART-TIME POETS",
        "CLAREITES",
        "TAVERNERS",
        "SHUTTERBUGS",
        "NETWORKERS",
        "TUBERS",
        "WRESTLERS",
        "MALTSTERS",
        "SCUNTHORPE SCHOLARS",
        "EUROVISIONARIES",
        "CHANNEL ISLANDERS",
        "BARDOPHILES",
        "HIGHGATES",
        "COUSINS",
        "WAYFARERS",
        "BOOKWORMS",
        "CLUESMITHS",
        "RAILWAYMEN",
        "YORKERS",
        "OPERATIONAL RESEARCHERS",
        "SCIENTISTS",
        "STRING SECTION",
        "ATHENIANS",
        "BUILDERS",
        "SPAGHETTI WESTERNERS",
        "MIXOLOGISTS",
        "ROAD TRIPPERS",
        "HEADLINERS",
        "COLLECTORS",
        "POLYGLOTS",
        "MUSIC MONKEYS",
        "CHESS PIECES",
        "ORIENTEERS",
        "CHESSMEN",
        "QI ELVES",
        "HISTORY BOYS",
        "GALLIFREYANS",
        "NORDIPHILES",
        "GAMESMASTERS",
        "LINGUISTS",
        "CODERS",
        "BIBLIOPHILES",
        "OXONIANS",
        "FELINOPHILES",
        "NIGHTWATCHMEN",
        "ROMANTICS",
        "WANDERING MINSTRELS",
        "POLITICOS",
        "WATERBABIES",
        "TILLERS",
        "NOGGINS",
        "CURIOSITIES",
        "EUROPHILES",
        "SOFTWARE ENGINEERS",
        "WELSH LEARNERS",
        "RELATIVES",
        "RECORD COLLECTORS",
        "HEATH FAMILY",
        "ERSTWHILE ATHLETES",
        "EXHIBITIONISTS",
        "BOARD GAMERS",
        "BAKERS",
        "LASLETTS",
        "OENOPHILES",
        "GLOBETROTTERS",
        "SCIENCE EDITORS",
        "PRESS GANG",
        "PILOTS",
        "SCRIBBLERS",
        "TERRIERS",
        "FRANCOPHILES",
        "CELTS",
        "CARTOPHILES",
        "FESTIVAL FANS",
        "FELL WALKERS",
        "CAT LOVERS",
        "GENERAL PRACTITIONERS",
        "CORPUSCLES",
        "SCRABBLERS",
        "THE BALDING TEAM",
        "WINTONIANS",
        "WORDSMITHS",
        "FOOTBALLERS",
        "CINEPHILES",
        "DRAUGHTSMEN",
        "NUMERISTS",
        "ACCOUNTANTS",
        "SCRIBES",
        "CIPHERS",
        "QUITTERS",
        "TRENCHERMEN",
        "EDUCATORS",
        "SECOND VIOLINISTS",
        "TEFL TEACHERS",
        "IT SPECIALISTS",
        "JOINEES",
        "THE WRIGHTS",
        "URBAN WALKERS",
        "GAMBLERS",
        "STRATEGISTS",
        "ARCHERS ADMIRERS",
        "EXETER ALUMNI",
        "BOOKSELLERS",
        "BOWLERS",
        "INSURERS",
        "GOURMANDS",
        "NEUROSCIENTISTS",
        "RUGBY FANS",
        "PHILOSOPHERS",
        "HITCHHIKERS",
        "CHOIR BOYS",
        "BRASENOSE POSTGRADS",
        "POLYMATHS",
        "MUSIC LOVERS",
        "CROSSWORDERS",
        "RUGBY BOYS",
        "MATHEMATICIANS",
        "CAMBRIDGE QUIZ SOCIETY",
        "CHARITY PUZZLERS",
        "OXFORD LIBRARIANS"
    };

    private static string[] _hieroglyphs = { "Two Reeds", "Lion", "Twisted Flax", "Horned Viper", "Water", "Eye of Horus" };

    private int _moduleId;
    private static int _moduleIdCounter = 1;

    private int _round1Answer;

    void Start()
    {
        _moduleId = _moduleIdCounter++;
        Module.OnActivate += delegate
        {
            var hieroglyphsDisplayed = Enumerable.Range(0, 6).ToArray();
            var serial = Bomb.GetSerialNumber();
            var serialProc = serial.Select(ch => ch == '0' ? 'Z' : ch >= '1' && ch <= '9' ? (char) (ch - '1' + 'A') : ch).JoinString();
            var hasPorts = Ut.NewArray(6, _ => Rnd.Range(0, 2) == 0);
            var retries = 0;

            retry:
            hieroglyphsDisplayed.Shuffle();
            var team = _teams[Rnd.Range(0, _teams.Length)];

            var matches = new int[6];
            for (int i = 0; i < 6; i++)
            {
                if (hieroglyphsDisplayed[i] == i)
                    matches[i]++;
                if (team.ToUpperInvariant().Contains(serialProc[i]))
                    matches[i]++;
                if (hasPorts[i])
                    matches[i]++;
            }

            var unique = Ut.NewArray(4, c => matches.Count(i => i == c) == 1);
            if (unique.Count(c => c) != 1)
            {
                retries++;
                goto retry;
            }

            TeamName.text = team.ToUpperInvariant();
            var uniqueCount = Array.IndexOf(unique, true);
            var round1Answer = Array.IndexOf(matches, uniqueCount);

            var format = @"[Only Connect #{0}] {1,-13} {2,-6} {3,-6} {4,-6} {5,-3} {6}";
            Debug.LogFormat(format, _moduleId, "Hieroglyph", "#1", "#2", "#3", "num", "");
            for (int i = 0; i < 6; i++)
            {
                var displayedHieroglyph = _hieroglyphs[hieroglyphsDisplayed[i]];
                EgyptianHieroglyphButtons[i].GetComponent<MeshRenderer>().material = EgyptianHieroglyphs[hieroglyphsDisplayed[i]];
                Debug.LogFormat(format, _moduleId, displayedHieroglyph, hieroglyphsDisplayed[i] == i, team.ToUpperInvariant().Contains(serialProc[i]), hasPorts[i], matches[i], i == _round1Answer ? "← ✓" : "");
                if (i == _round1Answer)
                    EgyptianHieroglyphButtons[i].OnInteract += StartRound2;
                else
                    EgyptianHieroglyphButtons[i].OnInteract += delegate
                    {
                        Debug.LogFormat(@"[Only Connect #{0}] {1} was the wrong Egyptian hieroglyph. Strike.", _moduleId, displayedHieroglyph);
                        Module.HandleStrike();
                        return false;
                    };
            }
        };
    }

    private bool StartRound2()
    {
        Debug.LogFormat(@"[Only Connect #{0}] Starting Round 2.", _moduleId);
        return false;
    }
}
