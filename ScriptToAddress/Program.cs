using NBitcoin;

do
{ 
    Console.WriteLine("Give me your scriptPubKey HEX and press ENTER.");
    var scriptPubKeyText = Console.ReadLine();
    Script scriptPubKey = Script.FromHex(scriptPubKeyText);

    Console.WriteLine($"Here is your address - press ENTER.");
    var address = scriptPubKey.GetDestinationAddress(Network.Main);
    Console.WriteLine(address.ToString());
}
while(true);

