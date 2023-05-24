using operatorok;

//1.Feladat
List<Kifejezes> kifejezesek = new List<Kifejezes>(File.ReadAllLines("kifejezesek.txt").Select(x => new Kifejezes(x)).ToList());

//2.Feladat
Console.WriteLine($"2.Feladat: {kifejezesek.Count}");

//3.Feladat
Console.WriteLine($"3.Feladat: {kifejezesek.Count(x => x.OperatorJele == "mod")}");

//4.Feladat
bool vanBenne = false;
int index = 0;

do
{
    vanBenne = kifejezesek[index].ElsoOperandus % 10 == 0 && kifejezesek[index].MasodikOperandus % 10 == 0;
    index++;
} while (vanBenne != true);

if (vanBenne == true)
{
    Console.WriteLine("4.Feladat: Van benne ilyen kifejezés!");
}
else
{
    Console.WriteLine("4.Feladat: Van benne ilyen kifejezés!");
}

//5.Feladat
Console.WriteLine("5.Feladat");
kifejezesek.Where(x => x.OperatorJele == "+" || x.OperatorJele == "-" || x.OperatorJele == "*" || x.OperatorJele == "/" || x.OperatorJele == "div" || x.OperatorJele == "mod").GroupBy(x => x.OperatorJele).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} -> {x.Count()} db"));

//7.Feladat
string kifejezes = "";
while (kifejezes != "vége")
{
	Console.WriteLine("7.Feladat: Kérem adjon meg egy kifejezést!");
	string eredmenyKezeloHasznalas = eredmenyKezelo(Console.ReadLine());
	if (eredmenyKezeloHasznalas == "vége")
	{
		kifejezes = "vége";
	}
	else
	{
		Console.WriteLine(eredmenyKezeloHasznalas);
	}
}

//8.Feladat
File.WriteAllLines("eredmenyek.txt", kifejezesek.Select(x => eredmenyKezelo($"{x.ElsoOperandus} {x.OperatorJele} {x.MasodikOperandus}")));
Console.WriteLine("8.Feladat: Kész a mentés!");











//6.Feladat
string eredmenyKezelo(string kifejezes)
{
	string beolvasottAdat = "";
	string visszateresiErtek = "";
	if (kifejezes == "vége")
	{
		return "Vége";
	}
	string[] feloszt = kifejezes.Split(' ');
	beolvasottAdat = feloszt[0] + " " + feloszt[1] + " " + feloszt[2];

	try
	{
		switch (feloszt[1])
		{
			case "+":
				visszateresiErtek = beolvasottAdat + " = " + (Convert.ToInt32(feloszt[0]) + Convert.ToInt32(feloszt[2]));
				break;
            case "-":
                visszateresiErtek = beolvasottAdat + " = " + (Convert.ToInt32(feloszt[0]) - Convert.ToInt32(feloszt[2]));
                break;
            case "*":
                visszateresiErtek = beolvasottAdat + " = " + (Convert.ToInt32(feloszt[0]) * Convert.ToInt32(feloszt[2]));
                break;
            case "/":
                visszateresiErtek = beolvasottAdat + " = " + (Convert.ToDouble(feloszt[0]) / Convert.ToDouble(feloszt[2]));
                break;
            case "div":
                visszateresiErtek = beolvasottAdat + " = " + (Convert.ToInt32(feloszt[0]) / Convert.ToInt32(feloszt[2]));
                break;
            case "mod":
                visszateresiErtek = beolvasottAdat + " = " + (Convert.ToInt32(feloszt[0]) % Convert.ToInt32(feloszt[2]));
                break;
            default:
				return$"{beolvasottAdat} = Hibás adat!";
		}
	}
	catch (Exception)
	{

		return "Más hiba!";
	}
	return visszateresiErtek;
}