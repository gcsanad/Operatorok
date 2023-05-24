using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorok
{
    internal class Kifejezes
    {
        int elsoOperandus;
        string operatorJele;
        int masodikOperandus;
        public Kifejezes(string sor)
        {
            string[] felosztas = sor.Split(' ');

            this.elsoOperandus = Convert.ToInt32(felosztas[0]);
            this.operatorJele = felosztas[1];
            this.masodikOperandus = Convert.ToInt32(felosztas[2]);
        }

        public int ElsoOperandus { get => elsoOperandus;}
        public string OperatorJele { get => operatorJele;}
        public int MasodikOperandus { get => masodikOperandus;}
    }
}
