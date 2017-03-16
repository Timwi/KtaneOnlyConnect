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

    public KMSelectable MainSelectable;

    public KMSelectable[] EgyptianHieroglyphButtons;
    public GameObject EgyptianHieroglyphsParent;
    public Material[] EgyptianHieroglyphs;
    public TextMesh TeamName;

    public GameObject ConnectingWallParent;
    public Material ButtonBackground;
    public Material[] ButtonSelected;

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

    private static string[] _alphabets = {
        "abcdefghijklmnopqrstuvxyzçöüğışǝ", // Azeri
        "abcdefghijklmnopqrstuvwxyzàçèéíïòóúü", // Catalan
        "abcdefghijklmnoprstuvzćčđšž", // Croatian
        "abcdefghijklmnopqrstuvwxyzáéíóúýčďěňřšťůž", // Czech
        "abcdefghijklmnopqrstuvwxyzåæø", // Danish
        "abcdefghijklmnoprstuvzĉĝĥĵŝŭ", // Esperanto
        "abcdefghijklmnopqrstuvzäõöüšž", // Estonian
        "adeghijklmnoprstuvyäö", // Finnish
        "abcdefghijklmnopqrstuvwxyzàâäæçèéêëîïôöùûüÿœ", // French
        "abcdefghijklmnopqrstuvwxyzßäöü", // German
        "abcdefghijklmnopqrstuvwxyzáéíóöúüőű", // Hungarian
        "abdefghijklmnoprstuvxyáæéíðóöúýþ", // Icelandic
        "abcdefghijklmnoprstuvzāčēģīķļņšūž", // Latvian
        "abcdefghijklmnoprstuvyząčėęįšūųž", // Lithuanian
        "abcdefghijklmnoprstuwyzóąćęłńśźż", // Polish
        "abcdefghijlmnopqrstuvxzàáâãçéêíóôõúü", // Portuguese
        "abcdefghijklmnopqrstuvwxyzâîășț", // Romanian
        "abcdefghijklmnopqrstuvwxyzáéíñóúü", // Spanish
        "abcdefghijklmnoprstuvwxyäåö", // Swedish
        "abcdefghijklmnoprstuvyzçöüğış", // Turkish
        "abcdefghijlmnoprstuwyŵŷ", // Welsh
    };

    private static string[] _alphabetNames = {
        "Azeri",
        "Catalan",
        "Croatian",
        "Czech",
        "Danish",
        "Esperanto",
        "Estonian",
        "Finnish",
        "French",
        "German",
        "Hungarian",
        "Icelandic",
        "Latvian",
        "Lithuanian",
        "Polish",
        "Portuguese",
        "Romanian",
        "Spanish",
        "Swedish",
        "Turkish",
        "Welsh",
    };

    private static string[] _hieroglyphs = { "Two Reeds", "Lion", "Twisted Flax", "Horned Viper", "Water", "Eye of Horus" };

    private int _moduleId;
    private static int _moduleIdCounter = 1;

    private int _round1Answer;

    void Start()
    {
        _moduleId = _moduleIdCounter++;
        EgyptianHieroglyphsParent.SetActive(false);
        ConnectingWallParent.SetActive(false);

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

            TeamName.text = team;
            var uniqueCount = Array.IndexOf(unique, true);
            _round1Answer = Array.IndexOf(matches, uniqueCount);

            Debug.LogFormat(@"[Only Connect #{0}] Team name: {1}", _moduleId, team);
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

            // Need extra nulls because child row length is 4
            MainSelectable.Children = new KMSelectable[8] { EgyptianHieroglyphButtons[0], EgyptianHieroglyphButtons[1], EgyptianHieroglyphButtons[2], null, EgyptianHieroglyphButtons[3], EgyptianHieroglyphButtons[4], EgyptianHieroglyphButtons[5], null };
            MainSelectable.UpdateChildren(EgyptianHieroglyphButtons[0]);

            EgyptianHieroglyphsParent.SetActive(true);
        };
    }

    private bool StartRound2()
    {
        EgyptianHieroglyphsParent.SetActive(false);
        ConnectingWallParent.SetActive(true);

        var retries = 0;

        retry:
        var wall = new char[4][];
        var names = new string[4];
        var commonToAll = "abcdefghijklmnopqrstuvwxyz".Where(ch => _alphabets.All(v => v.Contains(ch))).ToArray();
        var availableAlphabets = _alphabets.Select((abc, i) => new { Letters = new HashSet<char>(abc.Except(commonToAll)), Name = _alphabetNames[i] }).ToList();

        for (var i = 0; i < 4; i++)
        {
            var index = Rnd.Range(0, availableAlphabets.Count);
            var alphabet = availableAlphabets[index].Letters;
            wall[i] = alphabet.ToList().Shuffle().Take(4).ToArray();
            names[i] = availableAlphabets[index].Name;
            availableAlphabets.RemoveAt(index);
            var others = availableAlphabets.Where(a => wall[i].All(a.Letters.Contains)).ToList();
            var allLetters = alphabet.Concat(others.SelectMany(o => o.Letters)).Distinct().ToArray();
            foreach (var remaining in availableAlphabets)
                if (wall[i].Any(remaining.Letters.Contains))
                    foreach (var letter in allLetters)
                        remaining.Letters.Remove(letter);
            availableAlphabets.RemoveAll(s => s.Letters.Count < 4);
            if (availableAlphabets.Count == 0)
            {
                retries++;
                goto retry;
            }
        }

        Debug.LogFormat(@"[Only Connect #{0}] Connecting Wall solution:", _moduleId);
        for (int i = 0; i < 4; i++)
            Debug.LogFormat(@"[Only Connect #{0}] {1} {2} {3} {4} ({5})", _moduleId, wall[i][0], wall[i][1], wall[i][2], wall[i][3], names[i]);

        var curSelectedGroup = new List<char>();
        var numSolvedGroups = 0;

        var jumbledLetters = wall.SelectMany(row => row).ToList().Shuffle();
        var buttons = Enumerable.Range(0, 16).Select(i =>
        {
            var ch = jumbledLetters[i];
            var btn = ConnectingWallParent.transform.Find(string.Format("Button #{0}", i + 1));
            var renderer = btn.GetComponent<MeshRenderer>();
            renderer.material = ButtonBackground;
            var textMesh = btn.Find(string.Format("Button #{0} text", i + 1)).GetComponent<TextMesh>();
            textMesh.text = jumbledLetters[i].ToString();
            var sel = btn.GetComponent<KMSelectable>();
            sel.OnInteract += delegate
            {
                if (curSelectedGroup.Contains(ch))
                {
                    curSelectedGroup.Remove(ch);
                    renderer.material = ButtonBackground;
                }
                else
                {
                    curSelectedGroup.Add(ch);
                    renderer.material = ButtonSelected[numSolvedGroups];

                    if (curSelectedGroup.Count == 4)
                    {
                        var correctGroup = Enumerable.Range(0, 4).Select(ix => (int?) ix).FirstOrDefault(ix => !wall[ix.Value].Except(curSelectedGroup).Any() && !curSelectedGroup.Except(wall[ix.Value]).Any());
                        if (correctGroup == null)
                        {
                            Debug.LogFormat(@"[Only Connect #{0}] Submitted incorrect group: {1}", _moduleId, curSelectedGroup.JoinString(", "));
                        }
                    }
                }
                return false;
            };

            return new { Button = sel, Character = ch, Text = textMesh };
        }).ToArray();

        MainSelectable.Children = buttons.Select(inf => inf.Button).ToArray();
        MainSelectable.UpdateChildren(MainSelectable.Children[0]);
        buttons[0].Text.text = "\u01DD\u0259";

        return false;
    }
}
