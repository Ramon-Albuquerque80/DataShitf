using System;

namespace DataShift.Turnos
{
    public class Turno
    {
        public int Id { get; set; } 
        public string Lider { get; set; }
        public string Periodo { get; set; } 
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }

        public Turno() { }

        public Turno(string lider, string periodo, TimeSpan inicio, TimeSpan fim)
        {
            this.Lider = lider;
            this.Periodo = periodo;
            this.Inicio = inicio;
            this.Fim = fim;
        }
    }
}