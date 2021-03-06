using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using AdventOfCode.Contracts;

namespace AdventOfCode.Year2021
{
    class Day10 : IAdventDayPuzzle
    {
        public string Description => @"You ask the submarine to determine the best route out of the deep-sea cave, but it only replies:

Syntax error in navigation subsystem on line: all of them
All of them?! The damage is worse than you thought. You bring up a copy of the navigation subsystem (your puzzle input).";

        public DateTime Date => new DateTime(2021, 12, 10);
        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(Chunks), new Solution2(Chunks) };
        }

        private static readonly IReadOnlyDictionary<char, char> ClosingBracketMapping = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<','>' },
        };

        internal class Solution1 : IAdventDaySolution
        {
            private readonly string[] _chunks;

            private static IReadOnlyDictionary<char, int> Scores = new Dictionary<char, int>()
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 },
            };

            public Solution1(string[] chunks)
            {
                _chunks = chunks;
            }

            public string Description => @"Find the first illegal character in each corrupted line of the navigation subsystem. What is the total syntax error score for those errors?";
            public int Part => 1;
            public object Solve()
            {
                return _chunks
                    .Select(chunk => new { Value = chunk, ExpectedBrackets = new Stack<char>() })
                    .Sum(chunk => Scores.TryGetValue(chunk
                        .Value.FirstOrDefault((a) =>
                        {
                            if (Scores.Keys.Contains(a))
                            {
                                return chunk.ExpectedBrackets.TryPop(out var expectedBracket) && a != expectedBracket;
                            }

                            chunk.ExpectedBrackets.Push(ClosingBracketMapping[a]);
                            return false;
                        }), out var score) ? score : 0
                    );
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private readonly string[] _chunks;

            private static IReadOnlyDictionary<char, int> Scores = new Dictionary<char, int>()
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 },
            };

            public Solution2(string[] chunks)
            {
                _chunks = chunks;
            }

            public string Description => @"Find the completion string for each incomplete line, score the completion strings, and sort the scores. What is the middle score?";
            public int Part => 2;
            public object Solve()
            {
                var scores = _chunks
                    .Select(chunk => new { Value = chunk, ExpectedBrackets = new Stack<char>() })
                    .Where(chunk => chunk
                        .Value.All((a) =>
                        {
                            if (Scores.Keys.Contains(a))
                            {
                                return chunk.ExpectedBrackets.TryPop(out var expectedBracket) && a == expectedBracket;
                            }

                            chunk.ExpectedBrackets.Push(ClosingBracketMapping[a]);
                            return true;
                        }))
                    .Select(chunk => chunk.ExpectedBrackets.Aggregate(0L, (a, b) => (5 * a) + Scores[b]))
                    .OrderBy(s => s)
                    .ToArray();

                return scores[scores.Length / 2];
            }
        }

        internal static string[] Chunks => new[]
        {
            "{{{[(<<[[[<<([[]()]<()<>>)((()()))>([(()><{}[]>]({()[]}))>{[{(<>[]){{}[]}}<({}()){{}[]}>][<<(){}>(()<>)>{[{",
            "{<<((({{<<[<<{[]()}(())>([[]()])><[[{}{}]<[]<>>](({}())[{}<>])>][([{[]{}}](<<>{}>{()()})){({[]{}}<<><>>}{({}",
            "(<[{<{<(<[[<<<[][]>(<>)>><{<(){}>{[]{}}}<{{}[]}{()[]}]>][<([{}<>]<[]<>>)<{[]()}[()<>]>>[{{<><>}<<>{",
            "([{([{{{<[[{[{{}()}<{}[]>]{{<>()}<()>}}{<<{}()>{<>{}}>}]]<(<<[<><>]<<><>>>{<{}()>({}())}>){(<{()<>}><<<",
            "{(<{[{[{([<<{<()()>((){})}[[{}{})<()[]>]>>{([<{}<>><<>[]>]<{<>[]}[{}<>]>){<[<><>]{{}{}}><(",
            "[<([<(<{[<[{<<()[]>{()[]}>}{<[{}][[]{}]){[()()]{<>[]}}}]>{(<(<[]()><{}<>>)(<{}<>><{}()>)><<(<>())>>)",
            "(<{<[<[(({([(([][])([]())){(()[]){[][]}}][({[][]})[[[]{}]({}[])]])}{{{[{<>()}{()[]}](<{}[]><[]<>>)}<(",
            "<<(({([[[([{[[()()]{<>[]}]<[<>[]]({}[])>}]((<[[]())(()<>)>(<{}()>([][])))<([<>[]](()[]))>))[<[[<{}<>>([][])]",
            "(({[{[{<(({([{[]{}}(()())]{{()()}<<>()>})([{{}{}}[{}{}]]<<(){}>[()<>]>)}<{{(()[])}}{{[[]()",
            "[<{<<<{<[[[[(((){})(()[])){<[]{}>}](<[<>[]][<>()]><[()<>]<<>[]>>)]({{[<><>]}<<<>{}>[{}<>]>}[{{{}{}}([]{})}",
            "{[<({<{{<([(<<<>{}>{<>[]}>{{()<>}<<>{}>})(<<[]>((){})>)][<[<()<>>[()]]<((){})<<><>>>>[<{()[]}<{}[]>>]])>}{{<",
            "([[<{([{<<[{<[{}<>]{<>{}}>{[(){}][()()]}}<{(<>[])(<>())}([<><>])>]>{{{<([][]){<>()}>{([]()><()()>}}{{({}()",
            "(<[[({{<([[[[{{}<>}[<>()]][(<>[])<<>()>]]]([([[]()][()()])]([[{}[]]<{}[]>]{[{}<>]{<><>}}))))>(",
            "<<{[([(<<({{([{}[]]<<>()>)<<()[]>[{}<>]>}({(<><>)[{}()]})}[{<[(){}]>{{<>[]}[<>{}]}}[<(<><>){{}[]}>{{<>{",
            "[<({[({[<{[(<[{}()][{}<>]>{{()[]}(<>())})({{{}<>}<[]()>}{<()<>>})]}[<<{{[]}({}{})}([[]<>][()<>])>>[[[",
            "(<<[[<{<(<<<<[()[]]<<>()>>({[]<>}[[]()])>([<<><>>](([]()){[]()}))>{<[{{}<>}<<>[]>]<<<>><[]()>>>{",
            "<[[{[<({{[{(<([]())<{}[]>>(<<>{}>{<>})){[{[][]}{<>[]}]{[[]{}]<[]>}}}<<(([]{})[<>{}]){[{}()](<>{})}>[[([]{})[{",
            "([(<[<[[{([[(({}{})[(){}])([<>[]]{()[]})]([[()<>][<><>]])]{[<{[][]}[[][]]>{<[]()><()[]>}]<[(<>())<<>{}>]>})}",
            "([([{<<{{{({<<<>[]><<><>>>[[<>[]]<[]()>]}<<{[][]}[{}<>]>{[<>()]{()[]}}>)[[[<<><>>{(){}}>[({}[",
            "[[<[[({{(<[{<{[]{}>>({[]()}{[]<>})}{(([]{})[<>{}])[(<>{})<[][]>]}]>){{<[{<{}<>>}<([][])([]<>)>]((<(){}>(()",
            "([[{<[<((<{([{[]<>}({}[])]){{[[]]{<><>}}[<[][]>([][])]}}{[(((){})([]())>]{{{[]()}<<>()>}}}>){<[(",
            "{<(<{{<{[{<{{<(){}>{<><>}}}[{[{}<>][{}<>]}[[[]{}](()[])]]>}][<<<{[{}[]]<()()>}(((){})[()[]])>)((<(()",
            "{([<{<{([(<{[{{}[]}[(){}]]<{()}<{}()>>}[[[[]{}]{<>[]}}]>{[[[<>]<<>()>]{<()<>>{[]<>}}]})<<{[{<>()}<{}<>>]",
            "{<<(<[<[[[[{{(()())([]<>)](<<>>({}()))}<[{<>()}[()<>]]>]({[[[]()]<()<>>]}[[<[]<>><()<>>]{<{}()>[",
            "[<{(<<[<[(<[{(<>{})<{}()>}]<[[()<>]{<>()}]>>)]](({<{<[()()]{[]()}>((<>())(<>{}))}{[<{}()>]<(<>[",
            "[<({({[[[<{<[[()<>]<<><>>]{([]<>)([][])}>[[(<>[]){(){}}]]}{{<{<>{}}<<>>>(([]{})[[]<>])}[<(()[]){{}{}}>]}>[{",
            "{(<<{<[{[{({{[<><>]{{}[]}}}(([{}[]]<[]<>>)})[<(<[]{}><<>()>)[<{}<>>[<>[]]]>(<((){})[{}<>]>{(",
            "[<(({<<([{[{{{<><>}([]<>)}}]}](<(<[([][])<{}[]>]{{{}{}}[{}{}]}>{(<[][]>{{}{}})})>)){[([{{<[][]><()>}",
            "[({[[[(<<((<(<{}()>([]<>))(<()()}<{}[]>)>(([{}[]](<>{}))[{[]<>}(<>[])])))>>)][<{({<[[<{}{}>{[]()}]{(<>{}){",
            "{(([((([<[{[(({}[]){()<>})[[{}[]]({}())]]{<[[][]](()<>)>{[{}[]]{[]()}}}}<{(<<><>><()<>>)<({}[])",
            "{([{{[[{<({([[<><>]<{}<>>]<[()[]]<()[]>>)}[[{[{}{}]{{}{}}}]{[{[]{}}([]{})]{(()())[<>()]})])>}]<",
            "([<[{{{([{{<[[{}{}]]{<()()>}>{{{()[]}([]())}}}<<{<[][]>{<>{}}}>{[[{}()]([]{})]{([]{})(()())}}>}])<<<((<<{}{}",
            "[{{[<[[[<({[[<(){}>{{}[])]{{[]<>}([])}]}<({{<>()}[{}{}]}{[()()]{[]<>}})[{[()<>][()[]]}]>)>[<(<{{",
            "(<{{({{{[({([({}[])<{}{}>](([]{})[{}{}]))})[(<<((){}){()<>}>[[[]<>][{}[]]]>{<([]){{}<>}>([[]{}])}){[(((",
            "<[<{{(<(<<[{([(){}][()()])((<>())]}]>>)>)}[{(({({[[{(){}}]][{(()()){{}[]}}<(()())(<>())>]}{([{[]<>}<[]<>>]",
            "{({<[[<<{<{(({<>{}}<<>{}>))[<<{}()><<>()>><<(){}>({}())>]}<(([{}[]][{}{}]){<{}>}){[<[][]>((",
            "(<[{{[{([<<<(((){})([][]))>([[<>{}])[<{}()>{<>{}}])>>{{{{<[]{}>[()()]}[(<>{}){<>{}}]}{([[]{",
            "{(<[{({<<(<<<(<>())[{}[]]>>{([()()]({}{})){<[]()>[[]<>]}}>[[<[{}{}]{{}<>}>{[<>()][<><>]}]{<[<>][[]<>]>((<>{",
            "{[<<(<<({(<<[{<>[]}]{[{}{}]<[]()>}>(((())<<><>>)((<>{})[{}[]]))>[<({<><>}[[]{}])[<()[]>{()()}]>{{({}[])({}()",
            "<<<(<((([<{[{{{}<>}{{}[]}}[(<>)<<>[]>]]<[([])]<{()()}{<>{}}>>}><{<[[[]<>]<{}<>>]>[(({}[])<[]<>",
            "{<(([[{{[({(([[]{}]<{}()>)<([]())[[][]}>)<<<<>>{()[]}>[<<>()>]>})<<[({[]<>}[[]<>])<<{}()>({})>]{<<()[]>(()[",
            "([<([{<[<{<([<()>({}[])](<<>{}>{{}{}}))<<({}{}){{}()}>[([]{})[[]()]]>>{{<[()<>]{()<>}>((<>())[{}<>])}<[(<",
            "<([{({({<({[[(()[])[[][]]][(()){()[]}]](<{()<>}(()())><[[]()]([][])>)}{[{[<><>][{}{}]}<(<>[]){{}[]}>]",
            "(({[<<[[{{<[{{[][]}(()[])}{<()<>>}]([<[]<>><{}<>>]{<{}()>[<><>]})><{{<<>{}>[[]{}]}{<{}<>>[[]{})}}<<<{}<>>",
            "<{{<(({{(<[<<[[][]]{[]()}>><<{()[]}{<>)>(({}{})(()()))>]{(<({})({}{})>([()()]<{}<>>)){([{}[]]([]{}))[<[]",
            "{({[<<[[<[<(<{<>{}}{{}()]>([{}[]][()[]])){{[()[]]{<><>}}({<>()}[<>()])}><<{[()<>]<[]>}<({}[]",
            "<{{<<{<{<([(([<>()])<({}())<{}[]>>)[[(()())[()()]]{{()()}<{}()>}]])<[([<{}{}><[][]>])[[<[]<>>{[]<>}",
            "<{<([[<{[{([[[[][]]<[]<>>][({}()){()()}]]<(([]())[<>[]]){[()<>]}>)[[<<{}<>>([]{})>[(()<>)[[]()]]]]}((((<<>>",
            "[[{[<<([[({{<<{}<>>{<><>}>[<(){}>([]<>)]}<{<{}[]>{()[]}}((<>{})<()[]>}>}[<([[][]]([][]))({()()}<()",
            "[{[[{(<({(<({({}<>){{}[]}}{<<>[]>{()[]}})<(({}())[[]{}])>><[<{{}[]}>{<[][]>[()]}]{((<>{})(<>",
            "{{<{[[[(<({<(<[][]><{}<>>)[(<>{})<<><>>]>})>)]]]}{([[<<{[{<<()[]>({}{})>({{}()})}]<{[{()()}]<[[]]<()>>",
            "[{{[<((<<(({{[[]()]([]())}{<[]{}>[{}{}]}}<({<>{}}{()[]})<{{}}{{}[]}>>)(<<<{}[])<[]()>>({[]",
            "([[[<(<([{(({{{}[]}[{}]}[[()()][{}{}]]}({(<>{})({}())}({()()}([]<>)))){{({()<>}(<>[]))[(()())<[][]>",
            "{([<<{<(<((({({}[])({}[])}([<><>]([]())))<<<[]{}><<><>>>({{}[]}{()[]})>}(<[({}[]){<>[]}](<[][]>{{",
            "{{(<{<([[<[[(((){})<{}[]>)[[[]<>][<>()]]]{((<>[])(<>())){<<>>([]{})}}]<[([[][]][{}])]>><(({{<>()}}[<[][]>])",
            "{[[{<<<{{{[[(<(){}>{[]{}})]]}({<[[{}()][{}{}]]{({}[])[{}<>]}>{{{[]<>}[<>[]]}<{[][]}(<>[])>}})}{[<{[([][]){<",
            "<[<{<[{<({(<<([][])<()[]>><[<>()]{{}()}>)<([()<>]<<>{}>)(({}<>)[()<>])>)})>}][(<<<[[({{}()}{{}[",
            "<{{(<<{[{<{{{{[]<>}{()()}}{(<>()){()[]}}}[{(<>[])}(({}[])[()[]])]}<<[{<>()}]<{<>()}<{}()>>>{((<",
            "{[<[{{[[<[{<<[[][]]<{}[]>>><<<()[]>({}[])>>}([[[[][]]]((<>())<<>()>)](<[{}()]<[][]>>({<>[]}{[]()}))>]{{<[{{}",
            "<([[{[{<<(<{<[{}[]]{(){}}>(<{}<>>{<>()})}{(<(){}>{[]))((()<>)[{}[]])}><(<<(){}><()>>){(<()<>>(()()))<({}())[",
            "{<(<<{<[<<<[[<[]{}><[]()>]<{{}{}}{{}<>}>]>[[(<<><>>((){}))]({<()()><{}{}>}({<>()}))]>>]([(({<{()()}[",
            "([{[([({[[<[{(<>[])<<>()>}[[{}[]]<[][]>]]><(<<()<>>({}<>)><(()[])(()())>)({[[]{}]{<>()}}{[[]",
            "[(({([{[<<[{{((){})({}())}}]{{{<()<>>[[]()]}((<>[])(<>()))}[[[<><>]([]())]({()[]}{()[]})]}>>({[[<<",
            "<{{(([[[<(<(([[]()]<[]{}>))[<[{}{}](()())>[[()<>](()())]]>{<{<()<>>}(<{}<>>[[]()])>})>[({<",
            "[<{([{{<<{{(<([]{})[<>{}]>[<()<>><()[]>])({(()<>)<<>[]>)(([]{})([]<>)))}}>[{[({({}())[(){}]}<(",
            "<([<<[<(<<<<({()[]}<{}<>>)[[()[]][[]()]]><({{}{}}){[[][]]}>>{[((()[])[[][]]>{{()()}{()<>}}]<{<",
            "<((<{<{<{<<[[<<>()>{<>}]{({}[])<<><>>}]([{()<>}{[][]}]([[]<>](<>())))>[<<[[]<>]<()()>>[{()()}<(){",
            "<<{[{[{[<{{<<[<>()]<[]<>>>[[()()][{}{}]]>([{{}[]}<()<>>])}[((([]{})[[]<>])<<{}{}>{<>[]}))]}><[{(",
            "{{{{<<[{<{(({<{}()><[]<>>})[{<[]{}><()()>}{<<>[]>[[][]]}))<{<[<>[]][[]{}]>{[(){}][[]()]}}{{",
            "<<{([({{[{{<[<[][]>{[]<>}][<[]()>]>{{[{}][()[]]}({{}[]}[()[]])}}{[[<<>{}>](<()()>)][<[[]{}]<{}{}>>",
            "[{{<{([[<{(({<[]{}><[]()>}<<()<>><<>()>>)<{(<>()}[{}<>]}>){(<{<>{}}({}[])><{()<>}>)}}[({(<[]()>({}<>))<[[]",
            "{{{({({<{<{[[{[]{}}{[]()}]<{{}()}<{}[]>>]({<[]<>>[[]()]}<[<>[]}<{}<>>>)}{<<(()[])<()[]>>[(<>[])<()[]>]>(<[[](",
            "<{[(([[[([[<[[{}()]([]<>)][(()[])[<><>]]>(([<>{}]({}()))<{{}}[[][]]>)]({{<{}[]><[]()>}({[]{})[[",
            "{(<({({(<(<(([<>()][{}<>])<{()<>}<{}()>>)[[[()[]]<[]{}>][[()<>]<[]{}>]]>{<<<[]><[]()>><(<><>)<[]{}>>>})(([",
            "<{<(([(<<<<<{(()<>)}{<()()>(<>[])}>>>>>){{(<<[[{<>[]}(<><>)]<{[]{}}>]>>)[([{[[<><>]<()()>]{(()[])<<><>>}",
            "({{[(<([({((([()[]]{{}{}})[(<>{})([][])])){{({<><>}[()()]){<{}[]>[<><>]}}}}{(<[<<>[]>]>><<[{()}<()()>]",
            "([{[[([{<[({{({}[]><[][]>}}((<()()>[<>[]])<({}())({}())>))]<[[[(<>{}){[]}]{{[][]}{()[]}}]]<{<<{}<>><<",
            "({{<[[({{((<[{()<>}[{}[]]]([[]()](()[]))>{[{()[]}{{}[]}][{{}{}}{[]{}}]})({{[{}](<><>)}[([]()",
            "[<<{[{({{[[{{<[]{}>[<>[]]}<({}[])[()[]]>>{[[<>()]{{}[]}][{[]{}}{[]()}]}][<<([]()){[]<>}>((<>){{}()})>[{{{}(",
            "(<{[{<{[[[<[<{{}<>}<()>>{[<><>][()()]}][<[<>()]{{}{}}>([[]())[[]<>])]>]{[(<[()()]{<><>}>{[{}[]]<",
            "<{[[[{(({{<({(()[])(<>{})}(<[][]>[<>]))({([]<>)<<>[]>}<[<><>][()()]>)>[<[[<><>][()()]](<()>[()<>]",
            "[<[([[<<[{((<[<>{}][{}[]]><(<>{}){[]<>}>))}][{{<<<[][]><{}<>>>><({()[]}<()[]>)>}<([<(){}>({}())]<[{}][()]>)[",
            "[([({{[[{{[[{{{}{}}<[]<>>}]]<{{{{}{}}<<>()>}((()())({}[]))}[[<(){}>(<>{})][[<>{}]{{}<>}]]>",
            "<<[{<<([[({([[[][]]{{}()}])[[{{}[]}<{}()>]{[(){}]{<>[]}}]}([{{[][]}>]<{{()[]}<()[]>}<(()<>)",
            "[[[{(<[[{(({<({}())>{{<>{}}[{}{}]]}<{{()()}[{}<>]}[<{}<>>(<><>)]>))<<<{<<>[]>}{[{}()][{}{}]}>[<[(){}][{}{}",
            "{<([{[[([{[{(<()()><<>[]>)(({}{})[{}<>])}[<<()[]>[()<>]>{({}<>){()()}}]]<<{(<>[]){()()}}<{{}[]}(<><>)>>((",
            "(({{<(<({[[{({{}[]}([][]))[{[]<>}<<>[]>]}[<{[]{}}([])>]]{{([<>[]]({}()))(<()<>>{[]{}})}}][{<<{<>()",
            "{{[<[<(([<{[([()()][[]<>])[<()<>>{()[]}]]}>[{({{()()}([][])}({()}(()<>)))[[({}())]{{<>()}[<>]}]}]]{<{({({",
            "{{([([({[<((<{<><>}>{(<>[])})([({}{}){<>()}]))<[{<{}{}>{<>[]}}]<(<(){}>{()<>}){<<><>>}>>>[{[",
            "[<{<[(<{{[((<[<><>]{(){}}>(([]<>)[()()]))(<{{}()}[{}[]]>{<<><>>{()<>}}))({[<()()>{<><>}]<{[]<",
            "<((([(<[{<<[<<<>()>({})>][((()[]))<{{}()><<><>>>]>>({[[[<>{}][<><>]]({{}()}<{}{}>)]}((<<[]>",
            "[[{({[({[[[[<[<>()]{<>{}}>]{([<>{}](()<>))[[{}<>]({}[])]}]{{{(<>{})({}[]]}}[{[()<>]{()()}}]}]]<<{[((<>())<()<",
            "{<{{{([(<([<[{<>()}{<>{}}]<([]{})<[][]>>>([<(){}>[[][]]]{<()<>><<>[]>})]<<<[()()]>>[([()()]",
            "[([[(({[[{{<{(<>{})<(){}>}[({}{})[<><>]]>({<<>{}>[<>{}]})}}[[<{<()><{}{}>}{{<><>}}>([[()()]{{",
            "{{[({({([([<({()}([]()))>[[(<>[]){<><>}][{[]{}]<{}>]]]{{[({}{}){<><>}][[[]<>][<>[]]]}((([]<",
            "{{<<[<<(({[[{{{}()}({}{})}<{()[]}{()()}>][{{<>{}}[()<>]}([{}[]]{{}[]})]]<[{{[]<>}{<>{}}}{[<>[]]<[][]>}]",
            "[{<({({<{{({{{<>{}}<{}()>}{(<>())[<>{}]}}[(<<>{}>[{}])])((<<<><>><{}()>>(<<><>>([])))(<([]<>)>{{",
            "{[<[((<{{[{{<({}{})>}<((<>)<[]<>>)[[<>()]{{}}]>}]}}>))]({[{{([[<<<{}[]>><<<>()><<>[]>>>[{{(){}}}<[[]{}]({}",
            "<<<[<({[(<(<<(()<>)<{}{}>>{([]<>){<>{}}}>{{<{}<>>(<>{})}<[()<>]>})<{[({}())[<>[]]]({<>()}<<>{}>)><{",
            "({<<[{<<[{{<([(){}]<<>()>)<<<>()>[[]()]>>(<{<>()}([]())>{[[]<>](<>{})})}}]]{<(<<[<<><>>((){})]{",
            "<([{{[{<<[[{{[{}[]][()]}<[{}()][[][]]>}}[<{[<>[]]{{}()}}>{(<()()><[][]>)({()<>})}]]<[<[<{}<>>([]<>)",
            "([<<[[([(<<[({()<>})<{[]()}{()}>]({{()<>}})>{[([<>()]([]()))[{[]{}}]]}>{{{(<[]()><[]>)<{{}{}}[{",
            "([[{[[{<{[{<({()()}[<>{}])<<{}{}><<>()>>><[[<>{}](<>()]]<<[][]>{<>{}}>>}][<{(<<>()>[()[]])<{<>{}}",
            "<{<<{<((([{[<(())<{}[]>>]<(<{}()><<>{}>)<<<>{}>>>}<{{<<>()>{{}()}}<<(){}>>}[[{[]()}({}())]((<>",
            "([[([(<[<<{[<[()<>][[]()]>[[[]<>]<()()>]][[(<><>)]<<<>>(<>[])>]}><{([(<><>)]{[()<>}})}>><<[[(<",
            "{{(<<({<([([{{[]()}}([<>{}]{{}()})])])[[[[[[<>{}>({}())]{{[]{}}({}())}]]([{{<>}(()<>)}[{<>()}<[][]>]])](<[[[",
            "((({{<[<<{{{<<[]()>[<>[]]>[({}[])([]{})]}<<[[]{}]<()<>>><({}())(())>>}[<<[(){}]<[]()>>[{{}<>}",
            "[<([<{[([[[(<[<>{}]({}{})>([()[]]({})))([{()()}{()[]}]<[<><>]{()()}>)]({({(){}}{<><>})<[<>()]{{}()",
            "<(({(<[[{[{[((<>())[{}])[[<>]{<>()}]](<{[][]}{<>()}>([<>{}>{[]<>}))}[[({<>{}}{<>()})((()[])<<>",
            "<{{{{<{[[<[({{<>[]}(()<>)})<(<<>{}>[(){}])[{<>{}}{<>{}}]>]({[{<>()}<()<>>]{<[]()><{}()>}}([",
        };


    }
}
