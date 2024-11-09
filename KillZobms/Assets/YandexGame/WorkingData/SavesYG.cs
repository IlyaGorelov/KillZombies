
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public float fullVolume = 0;
        public float mouseSensetivity = 2;
        public float musicVolume = 0;
        public float soundVolume = 0;
        public int isVillageClean = 0;
        public int isMansionClean = 0;
        public int isDumpClean = 0;
        public int maxKillsVillage = 0;
        public int timeVillage = 0;
        public int maxKillsMan = 0;
        public int timeMan = 0;
        public int maxKillsDump = 0;
        public int timeDump = 0;

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
