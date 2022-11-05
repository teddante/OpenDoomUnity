public static class Globals
{
	internal const string rcsid = "$Id: i_main.c,v 1.4 1997/02/03 22:45:10 b1 Exp $";
	
	internal static void Main(int argc, string[] args)
	{
		myargc = argc;
		myargv = args;

		D_DoomMain();

	}
}