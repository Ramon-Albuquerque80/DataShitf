using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos
{
    public partial class Turno
    {
        
        public int ID { get; set; }
        public string Lider { get; set; }
        public string Periodo { get; set; }
        //TimeSpan representa um intervalo de tempo
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }

        public Turno() { }

        public Turno(string Lider, string Periodo, TimeSpan Inicio, TimeSpan Fim)
        {

            this.Lider = Lider;
            this.Periodo = Periodo;
            this.Inicio = Inicio;
            this.Fim = Fim;

        }

        public static void Decisao() {

            Console.Clear();
            Console.WriteLine("Deseja selecionar ou cadastrar um turno? (s/c)");
            char resposta = char.ToUpper(Console.ReadKey().KeyChar);

            if(resposta == 'S')
            {
                TurnoSelecao();

            } else if(resposta == 'C')
            {
                TurnoCadastro();
            }
        }

    }
}
