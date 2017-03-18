using System;
using System.Collections;
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

    public MeshRenderer ComponentRenderer;
    public Material ComponentBackgroundStage2;

    private static string[] _teams = {
        "ACCOUNTANTS",
        "ARCHERS ADMIRERS",
        "ATHENIANS",
        "BAKERS",
        "BARDOPHILES",
        "BEEKEEPERS",
        "BIBLIOPHILES",
        "BOARD GAMERS",
        "BOOKSELLERS",
        "BOOKWORMS",
        "BOWLERS",
        "BRASENOSE POSTGRADS",
        "BUILDERS",
        "CAMBRIDGE QUIZ SOCIETY",
        "CARTOPHILES",
        "CAT LOVERS",
        "CELTS",
        "CHANNEL ISLANDERS",
        "CHARITY PUZZLERS",
        "CHESS PIECES",
        "CHESSMEN",
        "CHOIR BOYS",
        "CINEPHILES",
        "CIPHERS",
        "CLAREITES",
        "CLUESMITHS",
        "CODERS",
        "COLLECTORS",
        "CORPUSCLES",
        "COSMOPOLITANS",
        "COUSINS",
        "CROSSWORDERS",
        "CURIOSITIES",
        "DRAUGHTSMEN",
        "EDUCATORS",
        "ERSTWHILE ATHLETES",
        "EUROPHILES",
        "EUROVISIONARIES",
        "EXETER ALUMNI",
        "EXHIBITIONISTS",
        "FELINOPHILES",
        "FELL WALKERS",
        "FESTIVAL FANS",
        "FIRE-EATERS",
        "FOOTBALLERS",
        "FRANCOPHILES",
        "GALLIFREYANS",
        "GAMBLERS",
        "GAMESMASTERS",
        "GENEALOGISTS",
        "GENERAL PRACTITIONERS",
        "GLOBETROTTERS",
        "GOURMANDS",
        "HEADLINERS",
        "HEATH FAMILY",
        "HIGHGATES",
        "HISTORY BOYS",
        "HITCHHIKERS",
        "INSURERS",
        "IT SPECIALISTS",
        "JOINEES",
        "KORFBALLERS",
        "LASLETTS",
        "LINGUISTS",
        "MALTSTERS",
        "MATHEMATICIANS",
        "MIXOLOGISTS",
        "MUSIC LOVERS",
        "MUSIC MONKEYS",
        "NETWORKERS",
        "NEUROSCIENTISTS",
        "NIGHTWATCHMEN",
        "NOGGINS",
        "NORDIPHILES",
        "NUMERISTS",
        "OENOPHILES",
        "OPERATIONAL RESEARCHERS",
        "ORIENTEERS",
        "OSCAR MEN",
        "OXFORD LIBRARIANS",
        "OXONIANS",
        "PART-TIME POETS",
        "PHILOSOPHERS",
        "PILOTS",
        "POLICY WONKS",
        "POLITICOS",
        "POLYGLOTS",
        "POLYMATHS",
        "PRESS GANG",
        "PSMITHS",
        "QI ELVES",
        "QUITTERS",
        "RAILWAYMEN",
        "RECORD COLLECTORS",
        "RELATIVES",
        "ROAD TRIPPERS",
        "ROMANTICS",
        "RUGBY BOYS",
        "RUGBY FANS",
        "SCIENCE EDITORS",
        "SCIENTISTS",
        "SCRABBLERS",
        "SCRIBBLERS",
        "SCRIBES",
        "SCUNTHORPE SCHOLARS",
        "SECOND VIOLINISTS",
        "SHUTTERBUGS",
        "SOFTWARE ENGINEERS",
        "SPAGHETTI WESTERNERS",
        "STRATEGISTS",
        "STRING SECTION",
        "SURREALISTS",
        "TAVERNERS",
        "TEFL TEACHERS",
        "TERRIERS",
        "THE BALDING TEAM",
        "THE WRIGHTS",
        "TILLERS",
        "TRENCHERMEN",
        "TUBERS",
        "URBAN WALKERS",
        "VERBIVORES",
        "WANDERING MINSTRELS",
        "WATERBABIES",
        "WAYFARERS",
        "WELSH LEARNERS",
        "WINTONIANS",
        "WORDSMITHS",
        "WRESTLERS",
        "YORKERS"
    };

    private static string[] _alphabets = {
        //!!
        "abcdefghijklmnopqrstuvxyzçë", // Albanian
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
        //@@
    };

    private static string[] _alphabetNames = {
        //##
        "Albanian",
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
        //$$
    };

    private static string[] _hieroglyphs = { "Two Reeds", "Lion", "Twisted Flax", "Horned Viper", "Water", "Eye of Horus" };

    private int _moduleId;
    private static int _moduleIdCounter = 1;
    private bool _isSolved;
    private int _round1Answer;

    void Start()
    {
        _moduleId = _moduleIdCounter++;
        _isSolved = false;

        StartCoroutine(InitialDisable());

        Module.OnActivate += delegate
        {
            var hieroglyphsDisplayed = Enumerable.Range(0, 6).ToArray();
            var serial = Bomb.GetSerialNumber();
            var serialProc = serial.Select(ch => ch == '0' ? 'Z' : ch >= '1' && ch <= '9' ? (char) (ch - '1' + 'A') : ch).JoinString();
            var hasPorts = Ut.NewArray(
                Bomb.IsPortPresent(KMBombInfoExtensions.KnownPortType.PS2),
                Bomb.IsPortPresent(KMBombInfoExtensions.KnownPortType.Parallel),
                Bomb.IsPortPresent(KMBombInfoExtensions.KnownPortType.RJ45),
                Bomb.IsPortPresent(KMBombInfoExtensions.KnownPortType.StereoRCA),
                Bomb.IsPortPresent(KMBombInfoExtensions.KnownPortType.Serial),
                Bomb.IsPortPresent(KMBombInfoExtensions.KnownPortType.DVI)
            );

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
                goto retry;

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
                Debug.LogFormat(format, _moduleId, displayedHieroglyph, hieroglyphsDisplayed[i] == i, team.Contains(serialProc[hieroglyphsDisplayed[i]]), hasPorts[hieroglyphsDisplayed[i]], matches[hieroglyphsDisplayed[i]], hieroglyphsDisplayed[i] == _round1Answer ? "← ✓" : "");
                if (hieroglyphsDisplayed[i] == _round1Answer)
                    EgyptianHieroglyphButtons[i].OnInteract = StartRound2(EgyptianHieroglyphButtons[i].transform);
                else
                    EgyptianHieroglyphButtons[i].OnInteract = delegate
                    {
                        Debug.LogFormat(@"[Only Connect #{0}] {1} was the wrong Egyptian hieroglyph. Strike.", _moduleId, displayedHieroglyph);
                        Module.HandleStrike();
                        return false;
                    };
            }

            EgyptianHieroglyphsParent.SetActive(true);
            // Need extra nulls because child row length is 4
            MainSelectable.Children = new KMSelectable[8] { EgyptianHieroglyphButtons[0], EgyptianHieroglyphButtons[1], EgyptianHieroglyphButtons[2], null, EgyptianHieroglyphButtons[3], EgyptianHieroglyphButtons[4], EgyptianHieroglyphButtons[5], null };
            MainSelectable.UpdateChildren(EgyptianHieroglyphButtons[0]);
        };
    }

    private IEnumerator InitialDisable()
    {
        yield return null;
        EgyptianHieroglyphsParent.SetActive(false);
        ConnectingWallParent.SetActive(false);
    }

    private KMSelectable.OnInteractHandler StartRound2(Transform pressedEgyptianHieroglyph)
    {
        return delegate
        {
            Audio.PlaySoundAtTransform("ButtonPress", pressedEgyptianHieroglyph);
            ConnectingWallParent.SetActive(true);
            StartCoroutine(ConnectingWallBackgroundAnimation(pressedEgyptianHieroglyph.position));

            retry:
            var wall = new char[4][];
            var names = new string[4];
            var commonToAll = "abcdefghijklmnopqrstuvwxyz".Where(ch => _alphabets.All(v => v.Contains(ch))).ToArray();
            var availableAlphabets = _alphabets.Select((abc, i) => new { Letters = new HashSet<char>(abc.Except(commonToAll)), Name = _alphabetNames[i] }).ToList();

            // Generate a possible connecting wall.
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
                    goto retry;
            }

            // Make sure that the wall has a unique solution.
            if (CheckWallUnique(wall.SelectMany(row => row).ToArray(), 0, 0, new Stack<string>(), Enumerable.Range(0, _alphabets.Length).ToDictionary(ix => _alphabetNames[ix], ix => new HashSet<char>(_alphabets[ix]))).Distinct().Skip(1).Any())
                goto retry;

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
                btn.transform.position = pressedEgyptianHieroglyph.position;
                var renderer = btn.GetComponent<MeshRenderer>();
                renderer.material = ButtonBackground;
                var textMesh = btn.Find(string.Format("Button #{0} text", i + 1)).GetComponent<TextMesh>();
                textMesh.text = jumbledLetters[i].ToString();
                var sel = btn.GetComponent<KMSelectable>();
                return new { Button = sel, Character = ch, Text = textMesh, Renderer = renderer };
            }).ToArray();

            StartCoroutine(MoveButtons(buttons.Select(b => b.Button).ToArray(), Enumerable.Range(0, 16).ToArray(), randomUpPosition: true));

            foreach (var inf_FE in buttons)
            {
                var inf = inf_FE;
                inf.Button.OnInteract += delegate
                {
                    var btnIx = Array.IndexOf(buttons, inf);
                    if (btnIx < 4 * numSolvedGroups || _isSolved)
                        return false;

                    Audio.PlaySoundAtTransform("Click", inf.Button.transform);

                    if (curSelectedGroup.Contains(inf.Character))
                    {
                        curSelectedGroup.Remove(inf.Character);
                        inf.Renderer.material = ButtonBackground;
                        inf.Text.color = Color.black;
                    }
                    else
                    {
                        curSelectedGroup.Add(inf.Character);
                        inf.Renderer.material = ButtonSelected[numSolvedGroups];
                        inf.Text.color = Color.white;

                        if (curSelectedGroup.Count == 4)
                        {
                            var correctGroup = Enumerable.Range(0, 4).Select(ix => (int?) ix).FirstOrDefault(ix => !wall[ix.Value].Except(curSelectedGroup).Any() && !curSelectedGroup.Except(wall[ix.Value]).Any());
                            if (correctGroup == null)
                            {
                                // User selected a wrong group: give a strike and reset the selected buttons
                                Debug.LogFormat(@"[Only Connect #{0}] Submitted incorrect group: {1}", _moduleId, curSelectedGroup.JoinString(", "));
                                Module.HandleStrike();
                                var btns = buttons.Where(inf2 => curSelectedGroup.Contains(inf2.Character)).ToArray();
                                StartCoroutine(ResetButtons(delegate
                                {
                                    foreach (var inf2 in btns)
                                        if (!curSelectedGroup.Contains(inf2.Character))
                                        {
                                            inf2.Renderer.material = ButtonBackground;
                                            inf2.Text.color = Color.black;
                                        }
                                }));
                            }
                            else
                            {
                                // User selected a correct group
                                Debug.LogFormat(@"[Only Connect #{0}] Submitted correct group: {1}", _moduleId, curSelectedGroup.JoinString(", "));

                                // Move the correct group to the top
                                for (int i = 0; i < 4; i++)
                                {
                                    var ix = buttons.IndexOf(b => b.Character == curSelectedGroup[i]);
                                    var t = buttons[4 * numSolvedGroups + i];
                                    buttons[4 * numSolvedGroups + i] = buttons[ix];
                                    buttons[ix] = t;
                                }
                                numSolvedGroups++;

                                if (numSolvedGroups == 3)
                                {
                                    for (int i = 12; i < 16; i++)
                                    {
                                        buttons[i].Renderer.material = ButtonSelected[3];
                                        buttons[i].Text.color = Color.white;
                                    }
                                    _isSolved = true;
                                    Module.HandlePass();
                                }

                                StartCoroutine(MoveButtons(buttons.Select(b => b.Button).ToArray(), curSelectedGroup.Select(ch => buttons.IndexOf(b => b.Character == ch)).ToArray()));
                            }
                            curSelectedGroup.Clear();
                        }
                    }
                    return false;
                };
            }

            MainSelectable.Children = buttons.Select(inf => inf.Button).ToArray();
            MainSelectable.UpdateChildren(MainSelectable.Children[0]);
            return false;
        };
    }

    private IEnumerator ResetButtons(Action action)
    {
        yield return new WaitForSeconds(.2f);
        action();
    }

    private static IEnumerable<string> CheckWallUnique(char[] chs, int index, int subIndex, Stack<string> already, Dictionary<string, HashSet<char>> alphabets)
    {
        if (index == 16)
        {
            yield return new string(chs);
            yield break;
        }

        if (index % 4 == 0)
        {
            foreach (var kvp in alphabets)
                if (kvp.Value.Contains(chs[index]) && !already.Contains(kvp.Key))
                {
                    already.Push(kvp.Key);
                    foreach (var solution in CheckWallUnique(chs, index + 1, index + 1, already, alphabets))
                        yield return solution;
                    already.Pop();
                }
        }
        else
        {
            var curAlph = alphabets[already.Peek()];
            for (int i = subIndex; i < 16; i++)
                if (curAlph.Contains(chs[i]))
                {
                    var t = chs[i];
                    chs[i] = chs[index];
                    chs[index] = t;
                    foreach (var solution in CheckWallUnique(chs, index + 1, i + 1, already, alphabets))
                        yield return solution;
                    t = chs[i];
                    chs[i] = chs[index];
                    chs[index] = t;
                }
        }
    }

    private IEnumerator ConnectingWallBackgroundAnimation(Vector3 startPosition)
    {
        yield return new WaitForSeconds(.25f);
        EgyptianHieroglyphsParent.SetActive(false);
        ComponentRenderer.material = ComponentBackgroundStage2;
    }

    private IEnumerator MoveButtons(KMSelectable[] buttons, int[] mustMove, bool randomUpPosition = false)
    {
        const float dx = .0375f;
        const float dy = .0225f;
        const float howFarUp = .03f;

        var infs = buttons.Select((b, i) =>
        {
            var oldPos = b.transform.localPosition;
            var newPos = new Vector3(dx * (i % 4) - (1.5f * dx), 0, dy * (-(i / 4)) + (1.5f * dy));
            return new
            {
                Button = b,
                OldPos = oldPos,
                OldPosUp = randomUpPosition ? new Vector3(Rnd.Range(-.05f, .05f), howFarUp, Rnd.Range(-.025f, .035f)) : new Vector3(oldPos.x, howFarUp, oldPos.z),
                NewPos = newPos,
                NewPosUp = new Vector3(newPos.x, howFarUp, newPos.z),
                ShouldMove = newPos != oldPos || mustMove.Contains(i),
                MustMove = mustMove.Contains(i)
            };
        }).ToArray();

        // Move towards camera
        const int steps1 = 10;
        for (int i = 0; i <= steps1; i++)
        {
            foreach (var inf in infs)
                if (inf.MustMove)
                    inf.Button.transform.localPosition = Vector3.Lerp(inf.OldPos, inf.OldPosUp, i / (float) steps1);
            yield return null;
        }

        yield return new WaitForSeconds(.3f);
        Audio.PlaySoundAtTransform("Woosh", buttons[0].transform);

        // Shuffle around
        const int steps2 = 20;
        for (int i = 0; i <= steps2; i++)
        {
            foreach (var inf in infs)
                if (inf.ShouldMove)
                    inf.Button.transform.localPosition = Vector3.Lerp(inf.OldPosUp, inf.NewPosUp, i / (float) steps2);
            yield return null;
        }

        yield return new WaitForSeconds(.05f);

        // Move to final position
        const int steps3 = 25;
        for (int i = 0; i <= steps3; i++)
        {
            foreach (var inf in infs)
                if (inf.ShouldMove)
                    inf.Button.transform.localPosition = Vector3.Lerp(inf.NewPosUp, inf.NewPos, i / (float) steps3);
            yield return null;
        }

        foreach (var inf in infs)
            if (inf.ShouldMove)
                inf.Button.transform.localPosition = inf.NewPos;
    }
}
