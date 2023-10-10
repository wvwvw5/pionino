using System;
using System.Threading;

class Piano
{
    private int[] currentOctave = new int[] { 261, 293, 329, 349, 392, 440, 493 }; // Частоты для октавы "C4" (Черный ключ - 7 нот)

    // Метод для вывода звука
    private void PlaySound(int frequency, int duration)
    {
        Console.Beep(frequency, duration);
    }

    // Метод для изменения октавы
    private int[] ChangeOctave(int octave)
    {
        // Здесь вы можете определить частоты для каждой октавы
        int[] octaveFrequencies = new int[7];

        for (int i = 0; i < 7; i++)
        {
            // Измените частоты в соответствии с выбранной октавой
            octaveFrequencies[i] = currentOctave[i] * (int)Math.Pow(2, octave - 4);
        }

        return octaveFrequencies;
    }

    public void Start()
    {
        int currentOctaveIndex = 4; // Изначально выбрана октава "C4"

        Console.WriteLine("Добро пожаловать в консольное пианино!");
        Console.WriteLine("Используйте клавиши A-S-D-F-G-H-J-K для воспроизведения нот.");
        Console.WriteLine("Для изменения октавы используйте клавиши F1-F2-F3.");
        Console.WriteLine("Для выхода нажмите Escape.");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
            else if (key.Key == ConsoleKey.F1)
            {
                currentOctaveIndex = 3; // Изменение октавы на "C3"
            }
            else if (key.Key == ConsoleKey.F2)
            {
                currentOctaveIndex = 4; // Изменение октавы на "C4"
            }
            else if (key.Key == ConsoleKey.F3)
            {
                currentOctaveIndex = 5; // Изменение октавы на "C5"
            }
            else
            {
                int noteIndex = "ASDFGHJK".IndexOf(char.ToUpper(key.KeyChar));
                if (noteIndex >= 0)
                {
                    int[] octaveFrequencies = ChangeOctave(currentOctaveIndex);
                    PlaySound(octaveFrequencies[noteIndex], 300);
                }
            }
        }
    }

    static void Main()
    {
        Piano piano = new Piano();
        piano.Start();
    }
}
