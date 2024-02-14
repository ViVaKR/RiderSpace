using CardGame;

// 먼저 순서대로 카드 52장 초기화
var cards = new List<Card>(52);
// Linq
cards.AddRange(
    from suit in Enum.GetValues(typeof(Suits)).OfType<Suits>()
    from value in Enum.GetValues(typeof(Values)).OfType<Values>()
    select new Card(suit, value));

// 카드 섞기 : 순서대로 정렬되어 초기화 완료된, 카드를 뒤에서부터 줄여가면서 랜더믹하게 섞기
// 섞은 것에서 또 섞기 위해서는 위 반듯한 초기화와 분리하여 아래 방법을 별도 메서드로 추출하여 
// 두번이먼 두번 세번이번 세번 고객의 믿음을 줄만큼, 반복 루핑을 돌리면됩니다.
Console.WriteLine("\t\t======= Card Shuffle =======");

int count;
bool check;
do {
    Console.Write("몇번 섞을 까요?: ");
    check = int.TryParse(Console.ReadLine(), out count);

} while (!check);

var line = string.Join(string.Empty, Enumerable.Repeat("=", Console.WindowWidth));
for (var i = 0; i < count; i++) {
    Console.WriteLine(line);
    Console.WriteLine($"\t{i + 1} 번째 섞기");
    var r = new Random();
    for (var n = cards.Count - 1; n >= 0; n--) {
        var k = r.Next(n + 1);
        (cards[n], cards[k]) = (cards[k], cards[n]);
    }

// 섞어진 카드 출력해 보기
    var cardOrderNumber = 0;
    Console.WriteLine($"\t[타입/번호]\t[영문명]\t\t[카드순번]");
    Console.WriteLine(line);
    foreach (var item in cards) {
        Console.WriteLine($"\t[{(char)item.Suit} {(int)item.Value,2}]\t\t" +
                          $"({item.Suit,-10}{item.Value}){string.Empty,-2}\t" +
                          $"{++cardOrderNumber,3}");
    }

    if(i == count -1) break;
    Console.WriteLine($"{i + 2} 번째 진행을 위하여 아무키나 누르세요..");
    Console.ReadLine();
}

Console.WriteLine("카드 섞기가 완료되었습니다.\n딜러는 카드를 노놔. 주세요!!\n\t\tStart Card Game!!");
Console.WriteLine("\t\t======= Good Luck =======");

