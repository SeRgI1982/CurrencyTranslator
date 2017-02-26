using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyTranslator.Controls
{
    public class CurrencyTextBox : TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);

            if (e.Text.Length > 0 && 
               (AllowOneCommaSeparator(e.Text[0]) || 
                AllowMinusAtTheBeginning(e.Text[0]) || 
                AllowTwoPlacesAfterComma(e.Text[0])))
            {
                e.Handled = false;
            } 
            else
            {
                e.Handled = true;
            }
        }

        private bool AllowOneCommaSeparator(char typedChar)
        {
            return typedChar == ',' && (!Text.Contains(",") && Text.Length > 0 || SelectedText.Length == Text.Length);
        }

        private bool AllowMinusAtTheBeginning(char typedChar)
        {
            return typedChar == '-' && (Text.Length == 0 || SelectedText.Length == Text.Length);
        }

        private bool AllowTwoPlacesAfterComma(char typedChar)
        {
            if (!char.IsDigit(typedChar))
            {
                return false;
            }

            return (!Text.Contains(",") && Text.Length <= 8) ||
                   (Text.IndexOf(",", StringComparison.InvariantCultureIgnoreCase) > 0 && Text.Substring(Text.IndexOf(",", StringComparison.InvariantCultureIgnoreCase)).Length <= 2 && Text.Length <= 11) ||
                   SelectedText.Length == Text.Length;
        }
    }
}
