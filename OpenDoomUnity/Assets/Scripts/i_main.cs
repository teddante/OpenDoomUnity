public static partial class Globals
{
	internal static void Main(int argc, string[] args)
	{
		myargc = argc;
		myargv = args;

		D_DoomMain();
	}
}