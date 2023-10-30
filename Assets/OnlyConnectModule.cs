using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        "ACADEMICALS",
        "ACCOUNTANTS",
        "ALESMEN",
        "ALSO RANS",
        "ANALYSTS",
        "ANCIENT ALUMNI",
        "ANIMAL LOVERS",
        "ANTIPHONS",
        "ANTIQUARIANS",
        "APOLLOS",
        "APRES SKIERS",
        "ARCHERS ADMIRERS",
        "ARROWHEADS",
        "ATHENIANS",
        "BACKHANDERS",
        "BAKERS",
        "BANKERS",
        "BARDOPHILES",
        "BARONS",
        "BEAKS",
        "BEEKEEPERS",
        "BELGOPHILES",
        "BIBLIOPHILES",
        "BIRDWATCHERS",
        "BIRKBECK ALUMNI",
        "BLOGGERS",
        "BOARD GAMERS",
        "BOOKKEEPERS",
        "BOOKSELLERS",
        "BOOKWORMS",
        "BOWLERS",
        "BRASENOSE POSTGRADS",
        "BREWS",
        "BRIDGE PLAYERS",
        "BRIDGES",
        "BRIT POPPERS",
        "BUILDERS",
        "CAMBRIDGE QUIZ SOCIETY",
        "CARTOONISTS",
        "CARTOPHILES",
        "CAT LOVERS",
        "CELTS",
        "CHANNEL ISLANDERS",
        "CHARITY PUZZLERS",
        "CHESS PIECES",
        "CHESSMEN",
        "CHOIR BOYS",
        "CHORISTERS",
        "CINEPHILES",
        "CIPHERS",
        "CLAREITES",
        "CLUESMITHS",
        "CODERS",
        "COLLEAGUES",
        "COLLECTORS",
        "CORKSCREWS",
        "CORPUSCLES",
        "COSMOPOLITANS",
        "COUNTRY WALKERS",
        "COUNTY COUNCILLORS",
        "COURTIERS",
        "COUSINS",
        "CRIBBAGERS",
        "CRICKET SUPPORTERS",
        "CRICKETERS",
        "CROOT FAMILY",
        "CROSSWORDERS",
        "CROSSWORDERS",
        "CRUSTACEANS",
        "CRYPTICS",
        "CUNNING PLANNERS",
        "CURIOSITIES",
        "CUTTERS",
        "DANDIES",
        "DARKSIDERS",
        "DATA WIZARDS",
        "DAVIDS",
        "DEBUGGERS",
        "DETECTIVES",
        "DICERS",
        "DISCOTHEQUES",
        "DISPARATES",
        "DOUBLE-OH SEVENS",
        "DRAGONS",
        "DRAUGHTSMEN",
        "DROP OF RED",
        "DUNGEON MASTERS",
        "DURHAMITES",
        "ECO-WARRIORS",
        "EDINBURGH SCRABBLERS",
        "EDITORS",
        "EDUCATORS",
        "EDWARDS FAMILY",
        "EGGCHASERS",
        "EGGHEADS",
        "ELECTROPHILES",
        "ENDEAVOURS",
        "EPICUREANS",
        "ERSTWHILE ATHLETES",
        "ESCAPOLOGISTS",
        "EUROPHILES",
        "EUROVISIONARIES",
        "EXETER ALUMNI",
        "EXHIBITIONISTS",
        "EXTRAS",
        "FANTASY FOOTBALLERS",
        "FANTASY WRITERS",
        "FELINOPHILES",
        "FELL WALKERS",
        "FESTIVAL FANS",
        "FIRE-EATERS",
        "FOOTBALLERS",
        "FORRESTS",
        "FOWLS",
        "FRANCOPHILES",
        "FREE SPEAKERS",
        "GAFFERS",
        "GALLIFREYANS",
        "GAMBLERS",
        "GAMEMAKERS",
        "GAMESMASTERS",
        "GARDNER",
        "GENEALOGISTS",
        "GENERAL PRACTITIONERS",
        "GEOCACHERS",
        "GLADIATORS",
        "GLOBETROTTERS",
        "GODYN FAMILY",
        "GOLDFINGERS",
        "GOLFERS",
        "GOURMANDS",
        "GREAT BELIEVERS",
        "GUNNERS",
        "HARLEQUINS",
        "HEADLINERS",
        "HEATH FAMILY",
        "HIGHGATES",
        "HISTORY BOYS",
        "HITCHHIKERS",
        "HOTPOTS",
        "IN-LAWS",
        "INORGANIC CHEMISTS",
        "INQUISITORS",
        "INSURERS",
        "IRREGULARS",
        "ISOTOPES",
        "IT SPECIALISTS",
        "IT SUPPORTERS",
        "JILLIES",
        "JOGGERS",
        "JOINEES",
        "JOURNEYMEN",
        "JUGADORES",
        "JUKEBOXERS",
        "JUNIPERS",
        "KNITTERS",
        "KORFBALLERS",
        "LAPSED PHYSICISTS",
        "LAPSED PSYCHOLOGISTS",
        "LARPERS",
        "LASLETTS",
        "LEXPLORERS",
        "LIBRARIANS",
        "LINGUISTS",
        "LISTENERS",
        "MALTSTERS",
        "MASTERMINDERS",
        "MATHEMATICIANS",
        "MEDICS",
        "MEEPLES",
        "MENSANS",
        "MERCIANS",
        "MIXOLOGISTS",
        "MORPORKIANS",
        "MOTHERS RUINED",
        "MOTORHEADS",
        "MOUNTAIN MEN",
        "MUPPETS",
        "MUSIC LOVERS",
        "MUSIC MONKEYS",
        "NETWORKERS",
        "NEUROMANTICS",
        "NEUROSCIENTISTS",
        "NIGHTWATCHMEN",
        "NOGGINS",
        "NORDIPHILES",
        "NUMERISTS",
        "OENOPHILES",
        "OMBUDSMEN",
        "OPERATIONAL RESEARCHERS",
        "ORIENTEERS",
        "ORWELLIANS",
        "OSCAR MEN",
        "OUTLIERS",
        "OXFORD LIBRARIANS",
        "OXONIANS",
        "PARISHIONERS",
        "PART-TIME POETS",
        "PEACOCKS",
        "PEDAGOGUES",
        "PHILOSOPHERS",
        "PILGRIMS",
        "PILOTS",
        "POLICY WONKS",
        "POLITICOS",
        "POLYGLOTS",
        "POLYHYMNIANS",
        "POLYMATHS",
        "POOL SHARKS",
        "POPTIMISTS",
        "PRESS GANG",
        "PSMITHS",
        "PUZZLE HUNTERS",
        "PYROMANIACS",
        "QI ELVES",
        "QUITTERS",
        "RADIO ADDICTS",
        "RAILWAYMEN",
        "RAMBLERS",
        "RECORD COLLECTORS",
        "RELATIVES",
        "ROADIES",
        "ROAD RUNNERS",
        "ROAD TRIPPERS",
        "ROCK'N'ROLLERS",
        "ROMANTICS",
        "ROWERS",
        "ROYAL III",
        "RUGBY BOYS",
        "RUGBY FANS",
        "SANDY SHORES",
        "SCIENCE EDITORS",
        "SCIENCE WRITERS",
        "SCIENTISTS",
        "SCRABBLERS",
        "SCRIBBLERS",
        "SCRIBES",
        "SCRUBS",
        "SCRUMMAGERS",
        "SCUNTHORPE SCHOLARS",
        "SEAGULLS",
        "SECOND VIOLINISTS",
        "SEVERNS",
        "SHUTTERBUGS",
        "SLIDERS",
        "SNAKE CHARMERS",
        "SOCIAL NETWORKERS",
        "SOFTWARE ENGINEERS",
        "SOLENT SCRABBLERS",
        "SOLOMONS FAMILY",
        "SPAGHETTI WESTERNERS",
        "STATISTICALS",
        "STEEL CITY SINGERS",
        "STEELERS",
        "STEWARDS",
        "STITCHERS",
        "STRATEGISTS",
        "STRIGIFORMES",
        "STRING SECTION",
        "SUNCATCHERS",
        "SUITS",
        "SURREALISTS",
        "TAVERNERS",
        "TAXONOMISTS",
        "TEACHERS",
        "TECHNOLOGISTS",
        "TEFL TEACHERS",
        "TEQUILA SLAMMERS",
        "TERRIERS",
        "THE BALDING TEAM",
        "THE WRIGHTS",
        "THEATRICALS",
        "THREE PEAKS",
        "THRIFTERS",
        "TICKET COLLECTORS",
        "TILLERS",
        "TIME LADIES",
        "TRADE UNIONISTS",
        "TRAVEL WRITERS",
        "TRENCHERMEN",
        "TUBERS",
        "TUROPHILES",
        "URBAN CYCLISTS",
        "URBAN WALKERS",
        "VEGETARIANS",
        "VERBIVORES",
        "VIDEO NASTIES",
        "VIKINGS",
        "VOLUNTEERS",
        "WALRUSES",
        "WANDERERS",
        "WANDERING MINSTRELS",
        "WATERBABIES",
        "WAYFARERS",
        "WELSH LEARNERS",
        "WESTENDERS",
        "WHITCOMBES",
        "WHODUNNITS",
        "WICKETS",
        "WILDLIFERS",
        "WINTONIANS",
        "WOMBLES",
        "WOOLGATHERERS",
        "WORDSMITHS",
        "WRESTLERS",
        "WRIGHTS",
        "YORKERS"
    };

    private static readonly string[] _alphabets = {
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
        "abcdefghijklmnopqrstuvwxyzäåö", // Swedish
        "abcdefghijklmnoprstuvyzçöüğış", // Turkish
        "abcdefghijlmnoprstuwyŵŷ", // Welsh
        //@@
    };

    private static readonly string[] _alphabetNames = {
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
    private bool _isRound2;
    private bool _isSolved;
    private int _round1Answer;
    private const int _wallSize = 3;
    private int[] _hieroglyphsDisplayed;
    private Round2ButtonInfo[] _round2Buttons;  // Contains the order in which they are displayed.
    private char[][] _round2Wall;   // Contains the correct groups, NOT the order in which they are displayed.
    private List<char> _curSelectedGroup;
    private int _numSolvedGroups;
    private int _animating = 0;

    void Start()
    {
        _moduleId = _moduleIdCounter++;
        _isRound2 = false;
        _isSolved = false;

        StartCoroutine(Initialize());
    }

    private KMSelectable.OnInteractHandler Round1Strike(int btnIx, int hierIx)
    {
        return delegate
        {
            EgyptianHieroglyphButtons[btnIx].AddInteractionPunch(1f);
            Debug.LogFormat(@"[Only Connect #{0}] {1} was the wrong Egyptian hieroglyph. Strike.", _moduleId, _hieroglyphs[hierIx]);
            Module.HandleStrike();
            return false;
        };
    }

    private IEnumerator Initialize()
    {
        yield return null;
        ConnectingWallParent.SetActive(false);

        _hieroglyphsDisplayed = Enumerable.Range(0, 6).ToArray();
        var serial = Bomb.GetSerialNumber();
        var serialProc = serial.Select(ch => ch == '0' ? 'Z' : ch >= '1' && ch <= '9' ? (char) (ch - '1' + 'A') : ch).JoinString();
        var ports = Ut.NewArray(
            KMBombInfoExtensions.KnownPortType.PS2,
            KMBombInfoExtensions.KnownPortType.Parallel,
            KMBombInfoExtensions.KnownPortType.RJ45,
            KMBombInfoExtensions.KnownPortType.StereoRCA,
            KMBombInfoExtensions.KnownPortType.Serial,
            KMBombInfoExtensions.KnownPortType.DVI
        );
        var hasPorts = ports.Select(port => Bomb.IsPortPresent(port)).ToArray();

        retry:
        _hieroglyphsDisplayed.Shuffle();
        var team = _teams[Rnd.Range(0, _teams.Length)];

        var matches = new int[6];
        for (int i = 0; i < 6; i++)
        {
            if (_hieroglyphsDisplayed[i] == i)
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
        var format = @"[Only Connect #{0}] {1,-13} {2,-9} {3,-8} {4,-9} {5,-3} {6}";
        Debug.LogFormat(format, _moduleId, "Hieroglyph", "Position", "Serial#", "Ports", "num", "");
        var positions = new[] { "TL", "TM", "TR", "BL", "BM", "BR" };
        for (int i = 0; i < 6; i++)
        {
            EgyptianHieroglyphButtons[i].GetComponent<MeshRenderer>().material = EgyptianHieroglyphs[_hieroglyphsDisplayed[i]];
            Debug.LogFormat(format, _moduleId, _hieroglyphs[i], positions[Array.IndexOf(_hieroglyphsDisplayed, i)] + "=" + (_hieroglyphsDisplayed[i] == i), serialProc[i] + "=" + team.Contains(serialProc[i]), ports[i].ToString().Substring(0, 2) + "=" + hasPorts[i], matches[i], i == _round1Answer ? "← ✓" : "");
            if (_hieroglyphsDisplayed[i] == _round1Answer)
                EgyptianHieroglyphButtons[i].OnInteract = StartRound2(EgyptianHieroglyphButtons[i]);
            else
                EgyptianHieroglyphButtons[i].OnInteract = Round1Strike(i, _hieroglyphsDisplayed[i]);
        }

        MainSelectable.Children = EgyptianHieroglyphButtons;
        MainSelectable.UpdateChildren(EgyptianHieroglyphButtons[0]);
    }

    private KMSelectable.OnInteractHandler StartRound2(KMSelectable pressedEgyptianHieroglyph)
    {
        return delegate
        {
            // Prevent accidental double-click
            if (_isRound2)
                return false;

            pressedEgyptianHieroglyph.AddInteractionPunch(1f);
            Audio.PlaySoundAtTransform("ButtonPress", pressedEgyptianHieroglyph.transform);
            ConnectingWallParent.SetActive(true);
            StartCoroutine(ConnectingWallBackgroundAnimation());

            retry:
            _round2Wall = new char[_wallSize][];
            var names = new string[_wallSize];
            var availableAlphabets = _alphabets.Select((abc, i) => new { Letters = new HashSet<char>(abc), Name = _alphabetNames[i] }).ToList();

            // Generate a possible connecting wall.
            for (var i = 0; i < _wallSize; i++)
            {
                var index = Rnd.Range(0, availableAlphabets.Count);
                var alphabet = availableAlphabets[index].Letters;
                _round2Wall[i] = alphabet.ToList().Shuffle().Take(_wallSize).ToArray();
                names[i] = availableAlphabets[index].Name;
                availableAlphabets.RemoveAt(index);
                var others = availableAlphabets.Where(a => _round2Wall[i].All(a.Letters.Contains)).ToList();
                var allLetters = alphabet.Concat(others.SelectMany(o => o.Letters)).Distinct().ToArray();
                foreach (var remaining in availableAlphabets)
                    if (_round2Wall[i].Any(remaining.Letters.Contains))
                        foreach (var letter in allLetters)
                            remaining.Letters.Remove(letter);
                availableAlphabets.RemoveAll(s => s.Letters.Count < _wallSize);
                if (availableAlphabets.Count == 0)
                    goto retry;
            }

            // Make sure that the wall has a unique solution.
            if (CheckWallUnique(_round2Wall.SelectMany(row => row).ToArray(), 0, 0, new Stack<string>(), Enumerable.Range(0, _alphabets.Length).ToDictionary(ix => _alphabetNames[ix], ix => new HashSet<char>(_alphabets[ix]))).Distinct().Skip(1).Any())
                goto retry;

            Debug.LogFormat(@"[Only Connect #{0}] Connecting Wall solution:", _moduleId);
            for (int i = 0; i < _wallSize; i++)
                Debug.LogFormat(@"[Only Connect #{0}] {1} ({2})", _moduleId, _round2Wall[i].JoinString(" "), names[i]);

            _curSelectedGroup = new List<char>();
            _numSolvedGroups = 0;

            var jumbledLetters = _round2Wall.SelectMany(row => row).ToList().Shuffle();
            _round2Buttons = Enumerable.Range(0, _wallSize * _wallSize).Select(i =>
            {
                var ch = jumbledLetters[i];
                var btn = ConnectingWallParent.transform.Find(string.Format("Button #{0}", i + 1));
                btn.transform.position = pressedEgyptianHieroglyph.transform.position;
                var renderer = btn.GetComponent<MeshRenderer>();
                renderer.material = ButtonBackground;
                var textMesh = btn.Find(string.Format("Button #{0} text", i + 1)).GetComponent<TextMesh>();
                textMesh.text = jumbledLetters[i].ToString();
                var sel = btn.GetComponent<KMSelectable>();
                return new Round2ButtonInfo { Button = sel, Character = ch, Text = textMesh, Renderer = renderer };
            }).ToArray();

            StartCoroutine(MoveButtons(_round2Buttons, Enumerable.Range(0, _wallSize * _wallSize).ToArray(), _round2Buttons, randomUpPosition: true));

            foreach (var inf in _round2Buttons)
            {
                inf.Button.OnInteract += delegate
                {
                    inf.Button.AddInteractionPunch(1f);
                    var btnIx = Array.IndexOf(_round2Buttons, inf);
                    if (btnIx < _wallSize * _numSolvedGroups || _isSolved)
                        return false;

                    Audio.PlaySoundAtTransform("Click", inf.Button.transform);

                    if (_curSelectedGroup.Contains(inf.Character))
                    {
                        _curSelectedGroup.Remove(inf.Character);
                        inf.Renderer.material = ButtonBackground;
                        inf.Text.color = Color.black;
                    }
                    else
                    {
                        _curSelectedGroup.Add(inf.Character);
                        inf.Renderer.material = ButtonSelected[_numSolvedGroups];
                        inf.Text.color = Color.white;

                        if (_curSelectedGroup.Count == _wallSize)
                        {
                            var correctGroup = Enumerable.Range(0, _wallSize).Select(ix => (int?) ix).FirstOrDefault(ix => !_round2Wall[ix.Value].Except(_curSelectedGroup).Any() && !_curSelectedGroup.Except(_round2Wall[ix.Value]).Any());
                            if (correctGroup == null)
                            {
                                // User selected a wrong group: give a strike and reset the selected buttons
                                Debug.LogFormat(@"[Only Connect #{0}] Submitted incorrect group: {1}", _moduleId, _curSelectedGroup.JoinString(" "));
                                Module.HandleStrike();
                                var btns2 = _round2Buttons.Where(inf2 => _curSelectedGroup.Contains(inf2.Character)).ToArray();
                                StartCoroutine(ResetButtons(delegate
                                {
                                    foreach (var inf2 in btns2)
                                        if (!_curSelectedGroup.Contains(inf2.Character))
                                        {
                                            inf2.Renderer.material = ButtonBackground;
                                            inf2.Text.color = Color.black;
                                        }
                                }));
                            }
                            else
                            {
                                // User selected a correct group
                                Debug.LogFormat(@"[Only Connect #{0}] Submitted correct group: {1}", _moduleId, _curSelectedGroup.JoinString(" "));

                                // Move the correct group to the top
                                for (int i = 0; i < _wallSize; i++)
                                {
                                    var ix = _round2Buttons.IndexOf(b => b.Character == _curSelectedGroup[i]);
                                    var t = _round2Buttons[_wallSize * _numSolvedGroups + i];
                                    _round2Buttons[_wallSize * _numSolvedGroups + i] = _round2Buttons[ix];
                                    _round2Buttons[ix] = t;
                                }
                                _numSolvedGroups++;

                                if (_numSolvedGroups == _wallSize - 1)
                                {
                                    for (int i = _wallSize * (_wallSize - 1); i < _wallSize * _wallSize; i++)
                                    {
                                        _round2Buttons[i].Renderer.material = ButtonSelected[_wallSize - 1];
                                        _round2Buttons[i].Text.color = Color.white;
                                    }
                                    _isSolved = true;
                                    Module.HandlePass();
                                    _numSolvedGroups++;
                                }

                                StartCoroutine(MoveButtons(
                                    _round2Buttons,
                                    _curSelectedGroup.Select(ch => _round2Buttons.IndexOf(b => b.Character == ch)).ToArray(),
                                    _round2Buttons.Skip(_wallSize * _numSolvedGroups).ToArray()));
                            }
                            _curSelectedGroup.Clear();
                        }
                    }
                    return false;
                };
            }

            _isRound2 = true;
            return false;
        };
    }

    private IEnumerator ResetButtons(Action action)
    {
        yield return new WaitForSeconds(.5f);
        action();
    }

    private static IEnumerable<string> CheckWallUnique(char[] chs, int index, int subIndex, Stack<string> already, Dictionary<string, HashSet<char>> alphabets)
    {
        if (index == _wallSize * _wallSize)
        {
            yield return new string(chs);
            yield break;
        }

        if (index % _wallSize == 0)
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
            for (int i = subIndex; i < _wallSize * _wallSize; i++)
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

    private IEnumerator ConnectingWallBackgroundAnimation()
    {
        _animating++;
        yield return new WaitForSeconds(.25f);
        EgyptianHieroglyphsParent.SetActive(false);
        ComponentRenderer.material = ComponentBackgroundStage2;
        _animating--;
    }

    private IEnumerator MoveButtons(Round2ButtonInfo[] buttons, int[] mustMove, Round2ButtonInfo[] newChildren, bool randomUpPosition = false)
    {
        _animating++;
        const float dx = .038f;
        const float dy = .024f;
        const float howFarUp = .02f;

        var infs = buttons.Select((b, i) =>
        {
            var oldPos = b.Button.transform.localPosition;
            var newPos = new Vector3(dx * (i % _wallSize) - dx, 0, dy * (-(i / _wallSize)) + dy);
            return new
            {
                Info = b,
                OldPos = oldPos,
                OldPosUp = randomUpPosition ? new Vector3(Rnd.Range(-.04f, .04f), howFarUp, Rnd.Range(-.02f, .03f)) : mustMove.Contains(i) ? new Vector3(oldPos.x, howFarUp, oldPos.z) : new Vector3(oldPos.x, howFarUp / 2, oldPos.z),
                NewPos = newPos,
                ShouldMove = newPos != oldPos || mustMove.Contains(i),
                MustMove = mustMove.Contains(i)
            };
        }).ToArray();

        // Move towards camera
        const float duration1 = .35f;
        var elapsed = 0f;
        while (elapsed < duration1)
        {
            yield return null;
            elapsed += Time.deltaTime;
            foreach (var inf in infs)
                if (inf.ShouldMove)
                    inf.Info.Button.transform.localPosition = Vector3.Lerp(inf.OldPos, inf.OldPosUp, Mathf.Min(1, elapsed / duration1));
        }

        yield return new WaitForSeconds(.15f);
        Audio.PlaySoundAtTransform("Woosh", buttons[0].Button.transform);

        // Move to final position
        const float duration2 = .6f;
        elapsed = 0;
        while (elapsed < duration2)
        {
            yield return null;
            elapsed += Time.deltaTime;
            foreach (var inf in infs)
                if (inf.ShouldMove)
                    inf.Info.Button.transform.localPosition = Vector3.Lerp(inf.OldPosUp, inf.NewPos, Mathf.Min(1, elapsed / duration2));
        }

        foreach (var inf in infs)
            if (inf.ShouldMove)
                inf.Info.Button.transform.localPosition = inf.NewPos;

        MainSelectable.Children = newChildren.Length == 0 ? new[] { EgyptianHieroglyphButtons[0] } : newChildren.Select(inf => inf.Button).ToArray();
        MainSelectable.UpdateChildren(newChildren.Length == 0 ? null : MainSelectable.Children[0]);
        _animating--;
    }

#pragma warning disable 414
    private string TwitchHelpMessage = @"Press a button by position with “!{0} press tm” or “!{0} press 2”. Round 1 also accepts symbol names (e.g. reeds, eye, flax, lion, water, viper).";
#pragma warning restore 414

    KMSelectable[] ProcessTwitchCommand(string command)
    {
        if (_isSolved)
            return null;

        var m = Regex.Match(command, @"^\s*(?:press\s+)?(.*)\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (!m.Success)
            return null;
        command = m.Groups[1].Value.ToLowerInvariant();

        if (!_isRound2)
        {
            // Round 1: Egyptian hieroglyphs
            switch (Regex.Replace(command, @"  +", " ").Replace("center", "middle").Replace("centre", "middle"))
            {
                case "two reeds": case "reeds": case "2 reeds": case "2reeds": return new[] { EgyptianHieroglyphButtons[Array.IndexOf(_hieroglyphsDisplayed, 0)] };
                case "lion": return new[] { EgyptianHieroglyphButtons[Array.IndexOf(_hieroglyphsDisplayed, 1)] };
                case "twisted flax": case "twistedflax": case "flax": return new[] { EgyptianHieroglyphButtons[Array.IndexOf(_hieroglyphsDisplayed, 2)] };
                case "horned viper": case "hornedviper": case "viper": return new[] { EgyptianHieroglyphButtons[Array.IndexOf(_hieroglyphsDisplayed, 3)] };
                case "water": return new[] { EgyptianHieroglyphButtons[Array.IndexOf(_hieroglyphsDisplayed, 4)] };
                case "eye of horus": case "eyeofhorus": case "eye": case "horus": return new[] { EgyptianHieroglyphButtons[Array.IndexOf(_hieroglyphsDisplayed, 5)] };

                case "tl": case "lt": case "lefttop": case "topleft": case "top left": case "left top": case "1": return new[] { EgyptianHieroglyphButtons[0] };
                case "tm": case "mt": case "tc": case "ct": case "middletop": case "topmiddle": case "top middle": case "middle top": case "2": return new[] { EgyptianHieroglyphButtons[1] };
                case "tr": case "rt": case "righttop": case "topright": case "top right": case "right top": case "3": return new[] { EgyptianHieroglyphButtons[2] };
                case "bl": case "lb": case "leftbottom": case "bottomleft": case "bottom left": case "left bottom": case "4": return new[] { EgyptianHieroglyphButtons[3] };
                case "bm": case "mb": case "bc": case "cb": case "middlebottom": case "bottommiddle": case "bottom middle": case "middle bottom": case "5": return new[] { EgyptianHieroglyphButtons[4] };
                case "br": case "rb": case "rightbottom": case "bottomright": case "bottom right": case "right bottom": case "6": return new[] { EgyptianHieroglyphButtons[5] };
            }
            return null;
        }
        else
        {
            // Round 2: Connecting Wall
            var btns = new List<KMSelectable>();
            foreach (var cmd in command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int number;
                if (int.TryParse(cmd, out number) && number >= 1 && number <= 9)
                    btns.Add(_round2Buttons[number - 1].Button);
                else if (cmd.Length == 1 && (number = _round2Buttons.IndexOf(inf => inf.Character == cmd[0])) != -1)
                    btns.Add(_round2Buttons[number].Button);
                else
                    switch (cmd.Replace("center", "middle").Replace("centre", "middle"))
                    {
                        case "tl": case "lt": case "topleft": case "lefttop": case "1": btns.Add(_round2Buttons[0].Button); break;
                        case "tm": case "tc": case "mt": case "ct": case "topmiddle": case "middletop": case "2": btns.Add(_round2Buttons[1].Button); break;
                        case "tr": case "rt": case "topright": case "righttop": case "3": btns.Add(_round2Buttons[2].Button); break;

                        case "ml": case "cl": case "lm": case "lc": case "middleleft": case "leftmiddle": case "4": btns.Add(_round2Buttons[3].Button); break;
                        case "mm": case "cm": case "mc": case "cc": case "middle": case "middlemiddle": case "5": btns.Add(_round2Buttons[4].Button); break;
                        case "mr": case "cr": case "rm": case "rc": case "middleright": case "rightmiddle": case "6": btns.Add(_round2Buttons[5].Button); break;

                        case "bl": case "lb": case "bottomleft": case "leftbottom": case "7": btns.Add(_round2Buttons[6].Button); break;
                        case "bm": case "bc": case "mb": case "cb": case "bottommiddle": case "middlebottom": case "8": btns.Add(_round2Buttons[7].Button); break;
                        case "br": case "rb": case "bottomright": case "rightbottom": case "9": btns.Add(_round2Buttons[8].Button); break;

                        default: return null;
                    }
            }

            // If any of the commands pointed to a button in an already-solved group, bail out
            if (btns.Any(b => b == null))
                return null;

            return btns.ToArray();
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        if (!_isRound2)
        {
            // Round 1: press the correct Egyptian hieroglyph
            var ix = Array.IndexOf(_hieroglyphsDisplayed, _round1Answer);
            EgyptianHieroglyphButtons[ix].OnInteract();
            while (_animating > 0)
                yield return true;
        }

        // If any buttons are already selected, deselect them
        while (_curSelectedGroup.Count > 0)
        {
            _round2Buttons.FirstOrDefault(inf => inf.Character == _curSelectedGroup[0]).Button.OnInteract();
            yield return new WaitForSeconds(.1f);
        }

        for (var i = 0; i < _wallSize; i++)
        {
            var btns = _round2Buttons.Where((inf, ix) => _round2Wall[i].Contains(inf.Character) && ix >= 3 * _numSolvedGroups).ToArray();
            //Debug.LogFormat(@"Group: {0}; {1}; {2}", _round2Wall[i].JoinString(), btns.Length);
            if (btns.Length == 0)
                continue;
            if (btns.Length != 3)
                throw new Exception("There is a bug in the TP autosolve handler. Please contact Timwi.");
            foreach (var btn in btns)
            {
                btn.Button.OnInteract();
                yield return new WaitForSeconds(.1f);
            }

            while (_animating > 0)
                yield return true;
        }
    }
}
