using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        string valorGuardado = "";

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void MouseSobreBotao(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            botao.BackColor  = Color.FromArgb(255, 183, 183, 183);
        }

        private void MouseSairBotao(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            botao.BackColor = Color.FromArgb(255, 243, 243, 243);
        }

        private void BotaoClick(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            //se o primeiro dígito for zero
            if (txtCalculo.Text =="0")
            {
                //despreza o zero e coloca o dígito clicado
                txtCalculo.Text = botao.Text;
            }
            //se o primeiro dígito é diferente de zero
            else
            {
                if (lblCalculo.Text == "")
                {
                    //acrescenta o número digitado
                    txtCalculo.Text = txtCalculo.Text + botao.Text;
                }
                else
                {
                    if (valorGuardado =="")
                    {
                        valorGuardado = txtCalculo.Text;

                        txtCalculo.Text = botao.Text;
                    }
                    else
                    {
                        //acrescenta o número digitado
                        txtCalculo.Text = txtCalculo.Text + botao.Text;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = "0";
            lblCalculo.Text = "";
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            int qtdCaracteres = 0;

            if (txtCalculo.Text != "0")
            {
                //guarda a quantidade de caracteres
                qtdCaracteres = txtCalculo.Text.Length;


                if (qtdCaracteres == 1)
                {
                    txtCalculo.Text = "0";
                }
                else if (qtdCaracteres > 1)
                {
                    txtCalculo.Text = txtCalculo.Text.Substring(0, qtdCaracteres-1);


                }
            }
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            

            //se contêm vírgula, adiciona
            if (!txtCalculo.Text.Contains(","))
            {
                txtCalculo.Text = txtCalculo.Text + ",";
            }
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            lblCalculo.Text = txtCalculo.Text + " +";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {

            if (lblCalculo.Text =="")
            {
                lblCalculo.Text = txtCalculo.Text + " =";
            }
            else
            {

                decimal valor1;
                decimal valor2;
                string operacao;

                lblCalculo.Text = lblCalculo.Text + " " + txtCalculo.Text + " =";

                valor1 = decimal.Parse (lblCalculo.Text.Split(' ')[0].ToString());

                operacao = lblCalculo.Text.Split(' ')[1].ToString();

                valor2 = decimal.Parse(lblCalculo.Text.Split(' ')[2].ToString());


                switch (operacao)
                {
                    case "+":
                        txtCalculo.Text = (valor1 + valor2).ToString();

                        break;

                    case "-":

                        txtCalculo.Text = (valor1 - valor2).ToString();

                        break;

                    case "/":

                        txtCalculo.Text = (valor1 / valor2).ToString();

                        break;

                    case "*":

                        txtCalculo.Text = (valor1 * valor2).ToString();

                        break;
                    
                }

            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            lblCalculo.Text = txtCalculo.Text +  " -";

        }

        private void btnVezes_Click(object sender, EventArgs e)
        {
            lblCalculo.Text = txtCalculo.Text + " *";
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            lblCalculo.Text = txtCalculo.Text + " /";
        }
    }
}
