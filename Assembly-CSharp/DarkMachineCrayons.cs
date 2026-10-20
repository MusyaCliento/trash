using UnityEngine;

public class DarkMachineCrayons : MonoBehaviour
{
	public static readonly Color aliceBlue = ColorFromHex(4042850303u);

	public static readonly Color antiqueWhite = ColorFromHex(4209760255u);

	public static readonly Color aqua = ColorFromHex(16777215u);

	public static readonly Color aquamarine = ColorFromHex(2147472639u);

	public static readonly Color azure = ColorFromHex(4043309055u);

	public static readonly Color beige = ColorFromHex(4126530815u);

	public static readonly Color bisque = ColorFromHex(4293182719u);

	public static readonly Color black = ColorFromHex(255u);

	public static readonly Color blanchedAlmond = ColorFromHex(4293643775u);

	public static readonly Color blue = ColorFromHex(65535u);

	public static readonly Color blueViolet = ColorFromHex(2318131967u);

	public static readonly Color brown = ColorFromHex(2771004159u);

	public static readonly Color burlywood = ColorFromHex(3736635391u);

	public static readonly Color cadetBlue = ColorFromHex(1604231423u);

	public static readonly Color chartreuse = ColorFromHex(2147418367u);

	public static readonly Color chocolate = ColorFromHex(3530104575u);

	public static readonly Color coral = ColorFromHex(4286533887u);

	public static readonly Color cornflowerBlue = ColorFromHex(1687547391u);

	public static readonly Color cornsilk = ColorFromHex(4294499583u);

	public static readonly Color crimson = ColorFromHex(3692313855u);

	public static readonly Color cyan = ColorFromHex(16777215u);

	public static readonly Color darkBlue = ColorFromHex(35839u);

	public static readonly Color darkCyan = ColorFromHex(9145343u);

	public static readonly Color darkGoldenrod = ColorFromHex(3095792639u);

	public static readonly Color darkGray = ColorFromHex(2846468607u);

	public static readonly Color darkGreen = ColorFromHex(6553855u);

	public static readonly Color darkKhaki = ColorFromHex(3182914559u);

	public static readonly Color darkMagenta = ColorFromHex(2332068863u);

	public static readonly Color darkOliveGreen = ColorFromHex(1433087999u);

	public static readonly Color darkOrange = ColorFromHex(4287365375u);

	public static readonly Color darkOrchid = ColorFromHex(2570243327u);

	public static readonly Color darkRed = ColorFromHex(2332033279u);

	public static readonly Color darkSalmon = ColorFromHex(3918953215u);

	public static readonly Color darkSeaGreen = ColorFromHex(2411499519u);

	public static readonly Color darkSlateBlue = ColorFromHex(1211993087u);

	public static readonly Color darkSlateGray = ColorFromHex(793726975u);

	public static readonly Color darkTurquoise = ColorFromHex(13554175u);

	public static readonly Color darkViolet = ColorFromHex(2483082239u);

	public static readonly Color deepPink = ColorFromHex(4279538687u);

	public static readonly Color deepSkyBlue = ColorFromHex(12582911u);

	public static readonly Color dimGray = ColorFromHex(1768516095u);

	public static readonly Color dodgerBlue = ColorFromHex(512819199u);

	public static readonly Color firebrick = ColorFromHex(2988581631u);

	public static readonly Color floralWhite = ColorFromHex(4294635775u);

	public static readonly Color forestGreen = ColorFromHex(579543807u);

	public static readonly Color fuchsia = ColorFromHex(4278255615u);

	public static readonly Color gainsboro = ColorFromHex(3705462015u);

	public static readonly Color ghostWhite = ColorFromHex(4177068031u);

	public static readonly Color gold = ColorFromHex(4292280575u);

	public static readonly Color goldenrod = ColorFromHex(3668254975u);

	public static readonly Color gray = ColorFromHex(3200171775u);

	public static readonly Color green = ColorFromHex(16711935u);

	public static readonly Color greenYellow = ColorFromHex(2919182335u);

	public static readonly Color honeydew = ColorFromHex(4043305215u);

	public static readonly Color hotPink = ColorFromHex(4285117695u);

	public static readonly Color indianRed = ColorFromHex(3445382399u);

	public static readonly Color indigo = ColorFromHex(1258324735u);

	public static readonly Color ivory = ColorFromHex(4294963455u);

	public static readonly Color khaki = ColorFromHex(4041641215u);

	public static readonly Color lavender = ColorFromHex(3873897215u);

	public static readonly Color lavenderBlush = ColorFromHex(4293981695u);

	public static readonly Color lawnGreen = ColorFromHex(2096890111u);

	public static readonly Color lemonChiffon = ColorFromHex(4294626815u);

	public static readonly Color lightBlue = ColorFromHex(2916673279u);

	public static readonly Color lightCoral = ColorFromHex(4034953471u);

	public static readonly Color lightCyan = ColorFromHex(3774873599u);

	public static readonly Color lightGoldenrod = ColorFromHex(4210742015u);

	public static readonly Color lightGray = ColorFromHex(3553874943u);

	public static readonly Color lightGreen = ColorFromHex(2431553791u);

	public static readonly Color lightPink = ColorFromHex(4290167295u);

	public static readonly Color lightSalmon = ColorFromHex(4288707327u);

	public static readonly Color lightSeaGreen = ColorFromHex(548580095u);

	public static readonly Color lightSkyBlue = ColorFromHex(2278488831u);

	public static readonly Color lightSlateGray = ColorFromHex(2005441023u);

	public static readonly Color lightSteelBlue = ColorFromHex(2965692159u);

	public static readonly Color lightYellow = ColorFromHex(4294959359u);

	public static readonly Color lime = ColorFromHex(16711935u);

	public static readonly Color limeGreen = ColorFromHex(852308735u);

	public static readonly Color linen = ColorFromHex(4210091775u);

	public static readonly Color magenta = ColorFromHex(4278255615u);

	public static readonly Color maroon = ColorFromHex(2955960575u);

	public static readonly Color mediumAquamarine = ColorFromHex(1724754687u);

	public static readonly Color mediumBlue = ColorFromHex(52735u);

	public static readonly Color mediumOrchid = ColorFromHex(3126187007u);

	public static readonly Color mediumPurple = ColorFromHex(2473647103u);

	public static readonly Color mediumSeaGreen = ColorFromHex(1018393087u);

	public static readonly Color mediumSlateBlue = ColorFromHex(2070474495u);

	public static readonly Color mediumSpringGreen = ColorFromHex(16423679u);

	public static readonly Color mediumTurquoise = ColorFromHex(1221709055u);

	public static readonly Color mediumVioletRed = ColorFromHex(3340076543u);

	public static readonly Color midnightBlue = ColorFromHex(421097727u);

	public static readonly Color mintCream = ColorFromHex(4127193855u);

	public static readonly Color mistyRose = ColorFromHex(4293190143u);

	public static readonly Color moccasin = ColorFromHex(4293178879u);

	public static readonly Color navajoWhite = ColorFromHex(4292783615u);

	public static readonly Color navyBlue = ColorFromHex(33023u);

	public static readonly Color oldLace = ColorFromHex(4260751103u);

	public static readonly Color olive = ColorFromHex(2155872511u);

	public static readonly Color oliveDrab = ColorFromHex(1804477439u);

	public static readonly Color orange = ColorFromHex(4289003775u);

	public static readonly Color orangeRed = ColorFromHex(4282712319u);

	public static readonly Color orchid = ColorFromHex(3664828159u);

	public static readonly Color paleGoldenrod = ColorFromHex(4008225535u);

	public static readonly Color paleGreen = ColorFromHex(2566625535u);

	public static readonly Color paleTurquoise = ColorFromHex(2951671551u);

	public static readonly Color paleVioletRed = ColorFromHex(3681588223u);

	public static readonly Color papayaWhip = ColorFromHex(4293907967u);

	public static readonly Color peachPuff = ColorFromHex(4292524543u);

	public static readonly Color peru = ColorFromHex(3448061951u);

	public static readonly Color pink = ColorFromHex(4290825215u);

	public static readonly Color plum = ColorFromHex(3718307327u);

	public static readonly Color powderBlue = ColorFromHex(2967529215u);

	public static readonly Color purple = ColorFromHex(2686513407u);

	public static readonly Color rebeccaPurple = ColorFromHex(1714657791u);

	public static readonly Color red = ColorFromHex(4278190335u);

	public static readonly Color rosyBrown = ColorFromHex(3163525119u);

	public static readonly Color royalBlue = ColorFromHex(1097458175u);

	public static readonly Color saddleBrown = ColorFromHex(2336560127u);

	public static readonly Color salmon = ColorFromHex(4202722047u);

	public static readonly Color sandyBrown = ColorFromHex(4104413439u);

	public static readonly Color seaGreen = ColorFromHex(780883967u);

	public static readonly Color seashell = ColorFromHex(4294307583u);

	public static readonly Color sienna = ColorFromHex(2689740287u);

	public static readonly Color silver = ColorFromHex(3233857791u);

	public static readonly Color skyBlue = ColorFromHex(2278484991u);

	public static readonly Color slateBlue = ColorFromHex(1784335871u);

	public static readonly Color slateGray = ColorFromHex(1887473919u);

	public static readonly Color snow = ColorFromHex(4294638335u);

	public static readonly Color springGreen = ColorFromHex(16744447u);

	public static readonly Color steelBlue = ColorFromHex(1182971135u);

	public static readonly Color tan = ColorFromHex(3535047935u);

	public static readonly Color teal = ColorFromHex(8421631u);

	public static readonly Color thistle = ColorFromHex(3636451583u);

	public static readonly Color tomato = ColorFromHex(4284696575u);

	public static readonly Color transparent = ColorFromHex(4294967040u);

	public static readonly Color turquoise = ColorFromHex(1088475391u);

	public static readonly Color violet = ColorFromHex(4001558271u);

	public static readonly Color webGray = ColorFromHex(2155905279u);

	public static readonly Color webGreen = ColorFromHex(8388863u);

	public static readonly Color webMaroon = ColorFromHex(2147483903u);

	public static readonly Color webPurple = ColorFromHex(2147516671u);

	public static readonly Color wheat = ColorFromHex(4125012991u);

	public static readonly Color white = ColorFromHex(uint.MaxValue);

	public static readonly Color whiteSmoke = ColorFromHex(4126537215u);

	public static readonly Color yellow = ColorFromHex(4294902015u);

	public static readonly Color yellowGreen = ColorFromHex(2597139199u);

	public static Color[] crayons = new Color[146]
	{
		ColorFromHex(4042850303u),
		ColorFromHex(4209760255u),
		ColorFromHex(16777215u),
		ColorFromHex(2147472639u),
		ColorFromHex(4043309055u),
		ColorFromHex(4126530815u),
		ColorFromHex(4293182719u),
		ColorFromHex(255u),
		ColorFromHex(4293643775u),
		ColorFromHex(65535u),
		ColorFromHex(2318131967u),
		ColorFromHex(2771004159u),
		ColorFromHex(3736635391u),
		ColorFromHex(1604231423u),
		ColorFromHex(2147418367u),
		ColorFromHex(3530104575u),
		ColorFromHex(4286533887u),
		ColorFromHex(1687547391u),
		ColorFromHex(4294499583u),
		ColorFromHex(3692313855u),
		ColorFromHex(16777215u),
		ColorFromHex(35839u),
		ColorFromHex(9145343u),
		ColorFromHex(3095792639u),
		ColorFromHex(2846468607u),
		ColorFromHex(6553855u),
		ColorFromHex(3182914559u),
		ColorFromHex(2332068863u),
		ColorFromHex(1433087999u),
		ColorFromHex(4287365375u),
		ColorFromHex(2570243327u),
		ColorFromHex(2332033279u),
		ColorFromHex(3918953215u),
		ColorFromHex(2411499519u),
		ColorFromHex(1211993087u),
		ColorFromHex(793726975u),
		ColorFromHex(13554175u),
		ColorFromHex(2483082239u),
		ColorFromHex(4279538687u),
		ColorFromHex(12582911u),
		ColorFromHex(1768516095u),
		ColorFromHex(512819199u),
		ColorFromHex(2988581631u),
		ColorFromHex(4294635775u),
		ColorFromHex(579543807u),
		ColorFromHex(4278255615u),
		ColorFromHex(3705462015u),
		ColorFromHex(4177068031u),
		ColorFromHex(4292280575u),
		ColorFromHex(3668254975u),
		ColorFromHex(3200171775u),
		ColorFromHex(16711935u),
		ColorFromHex(2919182335u),
		ColorFromHex(4043305215u),
		ColorFromHex(4285117695u),
		ColorFromHex(3445382399u),
		ColorFromHex(1258324735u),
		ColorFromHex(4294963455u),
		ColorFromHex(4041641215u),
		ColorFromHex(3873897215u),
		ColorFromHex(4293981695u),
		ColorFromHex(2096890111u),
		ColorFromHex(4294626815u),
		ColorFromHex(2916673279u),
		ColorFromHex(4034953471u),
		ColorFromHex(3774873599u),
		ColorFromHex(4210742015u),
		ColorFromHex(3553874943u),
		ColorFromHex(2431553791u),
		ColorFromHex(4290167295u),
		ColorFromHex(4288707327u),
		ColorFromHex(548580095u),
		ColorFromHex(2278488831u),
		ColorFromHex(2005441023u),
		ColorFromHex(2965692159u),
		ColorFromHex(4294959359u),
		ColorFromHex(16711935u),
		ColorFromHex(852308735u),
		ColorFromHex(4210091775u),
		ColorFromHex(4278255615u),
		ColorFromHex(2955960575u),
		ColorFromHex(1724754687u),
		ColorFromHex(52735u),
		ColorFromHex(3126187007u),
		ColorFromHex(2473647103u),
		ColorFromHex(1018393087u),
		ColorFromHex(2070474495u),
		ColorFromHex(16423679u),
		ColorFromHex(1221709055u),
		ColorFromHex(3340076543u),
		ColorFromHex(421097727u),
		ColorFromHex(4127193855u),
		ColorFromHex(4293190143u),
		ColorFromHex(4293178879u),
		ColorFromHex(4292783615u),
		ColorFromHex(33023u),
		ColorFromHex(4260751103u),
		ColorFromHex(2155872511u),
		ColorFromHex(1804477439u),
		ColorFromHex(4289003775u),
		ColorFromHex(4282712319u),
		ColorFromHex(3664828159u),
		ColorFromHex(4008225535u),
		ColorFromHex(2566625535u),
		ColorFromHex(2951671551u),
		ColorFromHex(3681588223u),
		ColorFromHex(4293907967u),
		ColorFromHex(4292524543u),
		ColorFromHex(3448061951u),
		ColorFromHex(4290825215u),
		ColorFromHex(3718307327u),
		ColorFromHex(2967529215u),
		ColorFromHex(2686513407u),
		ColorFromHex(1714657791u),
		ColorFromHex(4278190335u),
		ColorFromHex(3163525119u),
		ColorFromHex(1097458175u),
		ColorFromHex(2336560127u),
		ColorFromHex(4202722047u),
		ColorFromHex(4104413439u),
		ColorFromHex(780883967u),
		ColorFromHex(4294307583u),
		ColorFromHex(2689740287u),
		ColorFromHex(3233857791u),
		ColorFromHex(2278484991u),
		ColorFromHex(1784335871u),
		ColorFromHex(1887473919u),
		ColorFromHex(4294638335u),
		ColorFromHex(16744447u),
		ColorFromHex(1182971135u),
		ColorFromHex(3535047935u),
		ColorFromHex(8421631u),
		ColorFromHex(3636451583u),
		ColorFromHex(4284696575u),
		ColorFromHex(4294967040u),
		ColorFromHex(1088475391u),
		ColorFromHex(4001558271u),
		ColorFromHex(2155905279u),
		ColorFromHex(8388863u),
		ColorFromHex(2147483903u),
		ColorFromHex(2147516671u),
		ColorFromHex(4125012991u),
		ColorFromHex(uint.MaxValue),
		ColorFromHex(4126537215u),
		ColorFromHex(4294902015u),
		ColorFromHex(2597139199u)
	};

	public static Color ColorFromHex(uint val)
	{
		return new Color((float)(val >> 24) / 255f, (float)((val >> 16) & 0xFF) / 255f, (float)((val >> 8) & 0xFF) / 255f, (float)(val & 0xFF) / 255f);
	}

	public static int ColorToHex(Color color)
	{
		int num = Mathf.CeilToInt(Mathf.Clamp(color.r, 0f, 1f) * 255f);
		int num2 = Mathf.CeilToInt(Mathf.Clamp(color.g, 0f, 1f) * 255f);
		int num3 = Mathf.CeilToInt(Mathf.Clamp(color.b, 0f, 1f) * 255f);
		int num4 = Mathf.CeilToInt(Mathf.Clamp(color.a, 0f, 1f) * 255f);
		return (num << 24) | (num2 << 16) | (num3 << 8) | num4;
	}

	public static Color Arbitrary(int index)
	{
		return crayons[Mathf.Abs(index) % crayons.Length];
	}
}
