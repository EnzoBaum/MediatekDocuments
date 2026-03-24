using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Classe d'affichage
    /// </summary>
    public partial class FrmModifCmdLivre : Form
    {
        private FrmMediatekController controller;

        private Commande commande;

        /// <summary>
        /// Constructeur (valorise la commande sélectionnée)
        /// </summary>
        public FrmModifCmdLivre(Commande commande, FrmMediatekController controller)
        {
            InitializeComponent();
            this.commande = commande;
            this.controller = controller;

            RemplirComboSuivi();
            RemplirChamps();
        }

        /// <summary>
        /// Permet de remplir et de désactiver les champs
        /// </summary>
        private void RemplirChamps()
        {
            txbModifNumeroCommandeLivre.Text = commande.IdLivreDvd;
            txbModifMontantCommandeLivre.Text = commande.Montant.ToString();
            txbModifNbExemplairesCommandeLivre.Text = commande.NbExemplaire.ToString();
            dtpModifDateCommandeLivre.Value = commande.DateCommande;

            // désactive les champs non modifiables
            txbModifNumeroCommandeLivre.Enabled = false;
            txbModifMontantCommandeLivre.Enabled = false;
            txbModifNbExemplairesCommandeLivre.Enabled = false;
            dtpModifDateCommandeLivre.Enabled = false;
        }

        /// <summary>
        /// Permet de remplir le Combobox avec les étapes de suivi de la BDD
        /// </summary>
        private void RemplirComboSuivi()
        {
            List<Suivi> lesSuivis = controller.GetLesSuivis();

            cboModifEtapeSuiviCommandeLivre.DataSource = lesSuivis;
            cboModifEtapeSuiviCommandeLivre.DisplayMember = "Libelle";
            cboModifEtapeSuiviCommandeLivre.ValueMember = "Id";
            cboModifEtapeSuiviCommandeLivre.SelectedValue = commande.IdSuivi;
        }

        /// <summary>
        /// Permet de déterminer si une nouvelle étape est valide ou non
        /// </summary>
        /// <param name="ancienneEtape"></param>
        /// <param name="nouvelleEtape"></param>
        /// <returns></returns>
        private bool EtapeValide(string ancienneEtape, string nouvelleEtape)
        {
            if (ancienneEtape == "3")
                return false;

            if (ancienneEtape == "2" && (nouvelleEtape == "1" || nouvelleEtape == "4"))
                return false;

            if (ancienneEtape != "2" && nouvelleEtape == "3")
                return false;

            return true;
        }

        /// <summary>
        /// Permet de valider ou de refuser la modification de l'étape de suivi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidationModifCommande_Click(object sender, EventArgs e)
        {
            string nouvelleEtape = cboModifEtapeSuiviCommandeLivre.SelectedValue.ToString();

            if (!EtapeValide(commande.IdSuivi, nouvelleEtape))
            {
                MessageBox.Show("Modification de l'étape non autorisée.");
                cboModifEtapeSuiviCommandeLivre.SelectedValue = commande.IdSuivi;
                return;
            }

            controller.ModifierSuiviCommande(commande.Id, nouvelleEtape);

            MessageBox.Show("Étape modifiée avec succès.");
            Close();
        }
    }
}
