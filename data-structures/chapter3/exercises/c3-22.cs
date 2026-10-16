#!

var rand = new Random();
var myTestArray = Enumerable.Range(0, 100).Select(_ => rand.Next(1, 100)).ToArray();
for (int i = myTestArray.Length - 1; i > 0; i--)
{
    var j = rand.Next(0, i + 1);
    (myTestArray[i], myTestArray[j]) = (myTestArray[j], myTestArray[i]);
}
