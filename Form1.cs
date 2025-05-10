namespace calcolatrice
{
    public partial class Form1 : Form
    {
        double accumulatore = 0;
        String display = "";
        String operazione = "";
        bool nuovoNumero = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (nuovoNumero)
            {
                display = btn.Text;
                nuovoNumero = false;
            }
            else
            {
                display += btn.Text;
            }

            label1.Text = display;
        }


        private void Operazione_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double numeroCorrente = double.Parse(display);

            if (operazione != "")
            {
                EseguiOperazione(numeroCorrente);
            }
            else
            {
                accumulatore = numeroCorrente;
            }

            operazione = btn.Text;
            nuovoNumero = true;
        }


        private void Uguale_Click(object sender, EventArgs e)
        {
            double numeroCorrente = double.Parse(display);
            EseguiOperazione(numeroCorrente);
            operazione = "";
            nuovoNumero = true;
        }


        private void EseguiOperazione(double secondoNumero)
        {
            switch (operazione)
            {
                case "+":
                    accumulatore += secondoNumero;
                    break;
                case "-":
                    accumulatore -= secondoNumero;
                    break;
                case "x":
                    accumulatore *= secondoNumero;
                    break;
                case "/":
                    if (secondoNumero != 0)
                        accumulatore /= secondoNumero;
                    else
                    {
                        MessageBox.Show("Divisione per zero!");
                        return;
                    }
                    break;
            }

            display = accumulatore.ToString();
            label1.Text = display;
        }

        private void C_Click(object sender, EventArgs e)
        {
            accumulatore = 0;
            display = "";
            operazione = "";
            label1.Text = "0";
            nuovoNumero = true;
        }

        private void Virgola(object sender, EventArgs e)
        {
            display += ",";
            label1.Text = display;
        }
    }
}
