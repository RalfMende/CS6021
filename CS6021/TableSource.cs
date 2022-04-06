﻿using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace CS6021
{
    public class TableSource : UITableViewSource
    {
        public event EventHandler<int> LocomotiveSelected;
        List<Locomotive> TableItems;
        string CellIdentifier = "TableCell";

        public TableSource(List<Locomotive> locomotives)
        {
            this.TableItems = locomotives;
        }

        public override nint RowsInSection(UITableView tablVw_locomotives, nint section)
        {
            return TableItems.Count;
        }

        public override void RowSelected(UITableView tablVw_locomotives, NSIndexPath indexPath)
        {
            LocomotiveSelected(tablVw_locomotives, indexPath.Row);
        }

        public override UITableViewCell GetCell(UITableView tablVw_locomotives, NSIndexPath indexPath)
        {
            UITableViewCell cell = tablVw_locomotives.DequeueReusableCell(CellIdentifier);
            Locomotive item = TableItems[indexPath.Row];

            //if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            cell.TextLabel.Text = item.Address.ToString();

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
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
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
