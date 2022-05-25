using System.Collections.Generic;

public static class GlobalData
{
    public static List<float> zTrackPos = new List<float> { 0.2f, 1.6f, 3.0f };

    public static List<int[]> racersFormations = new List<int[]>
    {
        new int[]{1, 0, 0},
        new int[]{0, 1, 0},
        new int[]{0, 0, 1},
        new int[]{1, 1, 0},
        new int[]{0, 1, 1},
        new int[]{1, 0, 1}
    };
}
