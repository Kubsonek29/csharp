using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _24._04._2023
{
    public interface IMoveObject
    {
        void Move(Panel panelito);
        void Draw(PaintEventArgs e);
        void prepare();
        void MoveForResizeEnd(Panel panelito);
        void save(StreamWriter es);
        void load(StreamReader es);
        void save2(IMoveObject OneFigure, Stream s, BinaryFormatter bw);
        void load2(object OneFigure, Stream s, BinaryFormatter bw);
    }
}
