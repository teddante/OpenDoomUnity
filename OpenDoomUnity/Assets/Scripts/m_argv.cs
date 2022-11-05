public static partial class Globals
{
    public static int myargc;
    public static string[] myargv;
    
    public static int M_CheckParm(ref string check)
    {
        int i;

        for (i = 1; i < myargc; i++)
        {
            if (!strcasecmp(check, myargv[i]))
            {
                return i;
            }
        }

        return 0;
    }
}