using IField;
using McDroid;

namespace CSharpPlayersGuide.level33
{
    public class TheFued : IExercise
    {
        public void Run()
        {
            var sheep = new Sheep();
            var cow = new Cow();

            var pig1 = new IField.Pig();
            var pig2 = new McDroid.Pig();
        }
    }
}

namespace IField
{
    public class Sheep
    {

    }

    public class Pig
    {

    }
}


namespace McDroid
{
    public class Cow
    {

    }


    public class Pig
    {

    }
}


