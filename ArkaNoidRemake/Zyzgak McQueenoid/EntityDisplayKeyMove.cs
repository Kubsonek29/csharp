using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyzgak_McQueenoid
{
    public interface EntityDisplayKeyMove
    {
        public void displayentity(PaintEventArgs e);
        public void keypressMoveEntity(KeyPressEventArgs e);
    }
}
