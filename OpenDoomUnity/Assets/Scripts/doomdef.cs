public static partial class Globals
{
    public const int VERSION = 110;
}

public enum GameMode_t
{
    shareware, // DOOM 1 shareware, E1, M9
    registered, // DOOM 1 registered, E3, M27
    commercial, // DOOM 2 retail, E1 M34
    // DOOM 2 german edition not handled
    retail, // DOOM 1 retail, E4, M36
    indetermined // Well, no IWAD found.
}

public enum GameMission_t
{
    doom, // DOOM 1
    doom2, // DOOM 2
    pack_tnt, // TNT mission pack
    pack_plut, // Plutonia pack
    none
}

public enum Language_t
{
    english,
    french,
    german,
    unknown
}
static partial class DefineConstants
{
    public const int SNDSERV = 1;
    public const int BASE_WIDTH = 320;
    public const int SCREEN_MUL = 1;
    public const double INV_ASPECT_RATIO = 0.625; // 0.75, ideally
    public const int SCREENWIDTH = 320;
    public const int SCREENHEIGHT = 200;
    public const int MAXPLAYERS = 4;
    public const int TICRATE = 35;

}

public enum gamestate_t
{
    GS_LEVEL,
    GS_INTERMISSION,
    GS_FINALE,
    GS_DEMOSCREEN
}

internal static partial class DefineConstants
{
    public const int MTF_EASY = 1;
    public const int MTF_NORMAL = 2;
    public const int MTF_HARD = 4;
    public const int MTF_AMBUSH = 8;
}

public enum skill_t
{
    sk_baby,
    sk_easy,
    sk_medium,
    sk_hard,
    sk_nightmare
}

public enum card_t
{
    it_bluecard,
    it_yellowcard,
    it_redcard,
    it_blueskull,
    it_yellowskull,
    it_redskull,
    NUMCARDS
}

public enum weapontype_t
{
    wp_fist,
    wp_pistol,
    wp_shotgun,
    wp_chaingun,
    wp_missile,
    wp_plasma,
    wp_bfg,
    wp_chainsaw,
    wp_supershotgun,

    NUMWEAPONS,

    wp_nochange
}

public enum ammotype_t
{
    am_clip, // Pistol / chaingun ammo.
    am_shell, // Shotgun / double barreled shotgun.
    am_cell, // Plasma rifle, BFG.
    am_misl, // Missile launcher.
    NUMAMMO,
    am_noammo // Unlimited for chainsaw / fist.

}

public enum powertype_t
{
    pw_invulnerability,
    pw_strength,
    pw_invisibility,
    pw_ironfeet,
    pw_allmap,
    pw_infrared,
    NUMPOWERS

}

public enum powerduration_t
{
    INVULNTICS = (30 * DefineConstants.TICRATE),
    INVISTICS = (60 * DefineConstants.TICRATE),
    INFRATICS = (120 * DefineConstants.TICRATE),
    IRONTICS = (60 * DefineConstants.TICRATE)
}

internal static partial class DefineConstants
{
    public const int KEY_RIGHTARROW = 0xae;
    public const int KEY_LEFTARROW = 0xac;
    public const int KEY_UPARROW = 0xad;
    public const int KEY_DOWNARROW = 0xaf;
    public const int KEY_ESCAPE = 27;
    public const int KEY_ENTER = 13;
    public const int KEY_TAB = 9;
    
    public const int KEY_F1 = (0x80+0x3b);
    public const int KEY_F2 = (0x80+0x3c);
    public const int KEY_F3 = (0x80+0x3d);
    public const int KEY_F4 = (0x80+0x3e);
    public const int KEY_F5 = (0x80+0x3f);
    public const int KEY_F6 = (0x80+0x40);
    public const int KEY_F7 = (0x80+0x41);
    public const int KEY_F8 = (0x80+0x42);
    public const int KEY_F9 = (0x80+0x43);
    public const int KEY_F10 = (0x80+0x44);
    public const int KEY_F11 = (0x80+0x57);
    public const int KEY_F12 = (0x80+0x58);
    
    public const int KEY_BACKSPACE = 127;
    public const int KEY_PAUSE = 0xff;
    
    public const int KEY_EQUALS = 0x3d;
    public const int KEY_MINUS = 0x2d;

    public const int KEY_RSHIFT = (0x80+0x36);
    public const int KEY_RCTRL = (0x80+0x1d);
    public const int KEY_RALT = (0x80+0x38);
    
    public const int KEY_LALT = KEY_RALT;
}
