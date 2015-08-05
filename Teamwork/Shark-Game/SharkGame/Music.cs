using System;
using System.Threading;

namespace SharkGame
{
    class Music
    {
        public static Note[] Shark =
        {
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.Dsharp, Duration.QUARTER),
            new Note(Tone.C, Duration.QUARTER),
            new Note(Tone.D, Duration.QUARTER),
            new Note(Tone.Dsharp, Duration.QUARTER),
            new Note(Tone.Fsharp, Duration.QUARTER),
            new Note(Tone.G, Duration.HALF),
        };
        // Play the notes in a song. 
        public static void Play()
        {
            foreach (Note n in Shark)
            {
                if (n.NoteTone == Tone.REST)
                    Thread.Sleep((int)n.NoteDuration);
                else
                    Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
            }
        }

        // Define the frequencies of notes in an octave, as well as  
        // silence (rest). 
        public enum Tone
        {
            REST = 0,
            GbelowC = 196,
            A = 220,
            Asharp = 233,
            B = 247,
            C = 262,
            Csharp = 277,
            D = 294,
            Dsharp = 311,
            E = 330,
            F = 349,
            Fsharp = 370,
            G = 392,
            Gsharp = 415,
        }

        // Define the duration of a note in units of milliseconds. 
        public enum Duration
        {
            WHOLE = 1600,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
        }

        // Define a note as a frequency (tone) and the amount of  
        // time (duration) the note plays. 
        public struct Note
        {
            Tone toneVal;
            Duration durVal;

            // Define a constructor to create a specific note. 
            public Note(Tone frequency, Duration time)
            {
                toneVal = frequency;
                durVal = time;
            }

            // Define properties to return the note's tone and duration. 
            public Tone NoteTone { get { return toneVal; } }
            public Duration NoteDuration { get { return durVal; } }
        }
    }
}
