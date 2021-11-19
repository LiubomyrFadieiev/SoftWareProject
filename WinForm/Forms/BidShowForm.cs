using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DAL.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Realization;

namespace WinForm.Forms
{
    public partial class BidsShowForm : Form
    {
        GoodDTO good;
        UserDTO user;
        IAuctionManager auctionManager;
        public BidsShowForm(IAuctionManager auctionManager)
        {
            InitializeComponent();
            this.auctionManager = auctionManager;
        }
        public BidsShowForm(IAuctionManager aucm, GoodDTO good, UserDTO user)
        {
            auctionManager = aucm;
            this.good = good;
            this.user = user;
            InitializeComponent();
            this.Text = "List of Bids - " + good.goodsName; 
            RefreshGrid(auctionManager.GetGoodsBids(good));
        }
        private void RefreshGrid(List<BidDTO> bids)
        {
            bidsDataGrid.Rows.Clear();
            foreach (BidDTO bid in bids)
            {
                string fullname = (string)bid.userInformation[(int)UserInfo.firstName] + " " + bid.userInformation[(int)UserInfo.lastName];
                bidsDataGrid.Rows.Add(bid.user_id, fullname, bid.bid, bid.insertTime, bid.lastUpdateTime);
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            string body = String.Format($"Name: {good.goodsName}\nDescription: {good.goodsDesc}\nStartPrice:{good.startPrice}");
            MessageBox.Show(body, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addBidButton_Click(object sender, EventArgs e)
        {
            BidCreateForm form = new BidCreateForm(good);
            if(form.ShowDialog() == DialogResult.OK)
            {
                if (auctionManager.GetGoodsBids(good).Exists(u => u.user_id == user.user_id))
                {
                    auctionManager.UpdateBid(form.bid, good.good_id, user.user_id);
                }
                else
                {
                    BidDTO bid = new BidDTO(user.user_id, good.good_id, form.bid);
                    auctionManager.InsertBid(bid);
                }
                
                RefreshGrid(auctionManager.GetGoodsBids(good));
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshGrid(auctionManager.GetGoodsBids(good));
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            List<BidDTO> bids = auctionManager.GetGoodsBids(good);
            if(bids.Exists(u => u.user_id == user.user_id))
            {
                bids.Sort((b1,b2) => b1.bid.CompareTo(b2.bid));
                if (bids.Last().user_id == user.user_id)
                {
                    BoughtGoodDTO bgood = new BoughtGoodDTO(good.goodsName, good.goodsDesc, good.startPrice, bids.Last().bid, user.user_id);
                    auctionManager.BuyItem(good, bgood);
                    MessageBox.Show("Item is successfully buyed. Congratulations!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You cannot buy this item. Your bid is not the highest at the moment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You cannot buy this item. You have no bid on this item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}