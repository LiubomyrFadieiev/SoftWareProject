using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DAL.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Realization;

namespace WinForm.Forms
{
    public partial class MainForm : Form
    {
        public bool isLogOut;
        UserDTO authorisedUser;
        IAuctionManager auctionManager;


        public MainForm(IAuctionManager aucm, IAuthManager authm)
        {
            LogInForm login = new LogInForm(authm);
            if (login.ShowDialog() == DialogResult.OK)
            {
                isLogOut = false;
                auctionManager = aucm;
                authorisedUser = auctionManager.GetAuthorisedUser(login.authorisedlogin);
                InitializeComponent();
                RefreshGoodsGrid(auctionManager.GetAllGoods());

                greetLabel.Text = greetLabel.Text + authorisedUser.firstName + " " + authorisedUser.lastName + "!";
                List<BidDTO> bids = auctionManager.GetUsersBids(authorisedUser);
                RefreshBidsGrid(bids);

                List<BoughtGoodDTO> bgoods = auctionManager.GetUsersGoods(authorisedUser);
                RefreshBGoodsGrid(bgoods);
            }

        }

        private void RefreshGoodsGrid(List<GoodDTO> goods)
        {
            goodsDataGrid.Rows.Clear();
            foreach (GoodDTO good in goods)
            {
                goodsDataGrid.Rows.Add(good.good_id, good.goodsName, good.goodsDesc, good.startPrice, good.insertTime, good.lastUpdateTime);
            }
        }
        private void RefreshBidsGrid(List<BidDTO> bids)
        {
            bidDataGrid.Rows.Clear();
            foreach (BidDTO bid in bids)
            {
                bidDataGrid.Rows.Add(bid.good_id, bid.goodInformation[(int)GoodInfo.name], bid.goodInformation[(int)GoodInfo.description], bid.goodInformation[(int)GoodInfo.startPrice], bid.bid, bid.insertTime, bid.lastUpdateTime);
            }
        }
        private void RefreshBGoodsGrid(List<BoughtGoodDTO> bgoods)
        {
            bgoodsDataGrid.Rows.Clear();
            foreach(BoughtGoodDTO bgood in bgoods)
            {
                bgoodsDataGrid.Rows.Add(bgood.bgood_id, bgood.goodsName, bgood.goodsDesc, bgood.startPrice, bgood.endPrice, bgood.insertTime, bgood.lastUpdateTime);
            }
        }

        private void searchStripButton_Click(object sender, EventArgs e)
        {
            List<GoodDTO> searchedGoods = auctionManager.GetSearchedGoods(searchStripText.Text, searchStripComboBox.Text);
            if (searchedGoods.Count == 0)
            {
                MessageBox.Show($"There is no item with this {searchStripComboBox.Text}.", "No match", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RefreshGoodsGrid(searchedGoods);
            }

        }

        private void goodsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (goodsDataGrid[e.ColumnIndex, e.RowIndex] != null)
            {
                int id = Int32.Parse(goodsDataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
                GetBidForm(id);
            }
            RefreshGoodsGrid(auctionManager.GetAllGoods());
            RefreshBidsGrid(auctionManager.GetUsersBids(authorisedUser));
            RefreshBGoodsGrid(auctionManager.GetUsersGoods(authorisedUser));
        }
        private void bidDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bidDataGrid[e.ColumnIndex, e.RowIndex] != null)
            {
                int id = Int32.Parse(bidDataGrid.Rows[e.RowIndex].Cells["bidGoodId"].Value.ToString());
                GetBidForm(id);
            }
            
        }
        private void GetBidForm(int goodid)
        {
            GoodDTO good = auctionManager.GetGoodById(goodid);
            BidsShowForm bform = new BidsShowForm(auctionManager, good, authorisedUser);
            bform.Show();
        }

        private void outButton_Click(object sender, EventArgs e)
        {
            isLogOut = true;
            this.Close();
        }

        private void refreshBidsButton_Click(object sender, EventArgs e)
        {
            RefreshBidsGrid(auctionManager.GetUsersBids(authorisedUser));
        }

        private void refreshBGoodButton_Click(object sender, EventArgs e)
        {
            RefreshBGoodsGrid(auctionManager.GetUsersGoods(authorisedUser));
        }
    }
}
