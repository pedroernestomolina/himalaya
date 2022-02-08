using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sPago.Source.ToolPago.Lista
{
    
    public class data
    {


        public string provId { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public decimal importe { get; set; }
        public decimal acumulado { get; set; }
        public decimal resta { get; set; }
        public int cntDoc { get; set; }


        public data(string id, string nombre, string cirif, decimal importe, decimal resta, decimal acum, int cntDoc) 
        {
            this.provId = id;
            this.provNombre = nombre;
            this.provCiRif = cirif;
            this.importe = importe;
            this.resta = resta;
            this.acumulado = acum;
            this.cntDoc = cntDoc;
        }

        public void AgregarDoc(decimal monto)
        {
            this.importe += monto;
            this.resta += monto;
            this.cntDoc += 1;
        }

        public void ActualizarItem(data data)
        {
            this.importe = data.importe;
            this.resta = data.resta;
            this.acumulado = data.acumulado ;
            this.cntDoc = data.cntDoc;
        }

    }

}