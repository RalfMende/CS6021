/*
 * CS6021 - iPad Remote Controller for Märklin Central Station in ControlUnit-Design
 * 
 * Copyright (c) 2022 Ralf Mende
 * 
 * 
 * This file is part of CS6021.
 * 
 * CS6021 is free software: you can redistribute it and/or modify it 
 * under the terms of the GNU General Public License as published by the 
 * Free Software Foundation, either version 3 of the License, or (at your 
 * option) any later version.
 * 
 * CS6021 is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License 
 * along with Foobar. If not, see 
 * <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using HardwareControllers;

namespace CS6021
{
    public class TableSourceKeyboard : UITableViewSource
    {
        public event EventHandler<int> KeyboardSelected;
        List<Keyboard> TableItems;
        string CellIdentifier = "TableCell";

        public TableSourceKeyboard(List<Keyboard> keyboards)
        {
            this.TableItems = keyboards;
        }

        public override nint RowsInSection(UITableView tablVw_keyboards, nint section)
        {
            return TableItems.Count;
        }

        public override void RowSelected(UITableView tablVw_keyboards, NSIndexPath indexPath)
        {
            KeyboardSelected(tablVw_keyboards, indexPath.Row);
        }

        public override UITableViewCell GetCell(UITableView tablVw_keyboards, NSIndexPath indexPath)
        {
            UITableViewCell cell = tablVw_keyboards.DequeueReusableCell(CellIdentifier);
            Keyboard item = TableItems[indexPath.Row];

            //if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            cell.TextLabel.Text = item.nameOfInstance;

            return cell;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source
                    TableItems.RemoveAt(indexPath.Row);
                    // delete the row from the table
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;

                /*case UITableViewCellEditingStyle.None:
                    break;*/
            }
        }

        /*
        // If CommitEditingStyle is overridden, all rows are assumed to be editable. If this method is implemented and returns false (for some specific rows, or for all rows) then the swipe-to-delete gesture will not be available in that cell.
        public override bool CanEditRow(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
           return true;
        }

        // Optionally specifies the text for the Delete button. If this method is not implemented the button text will be “Delete”.
        public override string TitleForDeleteConfirmation(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
           return "Delete";
        }*/
    }
}
