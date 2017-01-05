﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace PlaneAlerter {
	public partial class SettingsForm :Form {
		public SettingsForm() {
			InitializeComponent();
			smtpHostInfo.hostInfo.Clear();
			smtpHostInfo.hostInfo.Add("smtp.gmail.com", new object[] { 587, true });
			smtpHostInfo.hostInfo.Add("smtp.live.com", new object[] { 587, true });
			smtpHostInfo.hostInfo.Add("smtp.office365.com", new object[] { 587, true });
			smtpHostInfo.hostInfo.Add("smtp.mail.yahoo.com", new object[] { 465, true });
			smtpHostInfo.hostInfo.Add("plus.smtp.mail.yahoo.com", new object[] { 465, true });
			smtpHostInfo.hostInfo.Add("smtp.mail.yahoo.co.uk", new object[] { 465, true });
			smtpHostInfo.hostInfo.Add("smtp.mail.yahoo.com.au", new object[] { 465, true });
			smtpHostInfo.hostInfo.Add("smtp.att.yahoo.com", new object[] { 465, true });
			smtpHostInfo.hostInfo.Add("smtp.comcast.net", new object[] { 587, false });
			smtpHostInfo.hostInfo.Add("outgoing.verizon.net", new object[] { 465, true });
			smtpHostInfo.hostInfo.Add("smtp.mail.com", new object[] { 465, true });

			foreach (string smtpHost in smtpHostInfo.hostInfo.Keys)
				smtpHostComboBox.Items.Add(smtpHost);

			senderEmailTextBox.Text = Settings.senderEmail;
			aircraftListTextBox.Text = Settings.acListUrl;
			radarURLTextBox.Text = Settings.radarUrl;
			VRSUsrTextBox.Text = Settings.VRSUsr;
			VRSPwdTextBox.Text = Settings.VRSPwd;
			latTextBox.Value = Settings.Lat;
			longTextBox.Value = Settings.Long;
			removalTimeoutTextBox.Value = Settings.timeoutLength;
			refreshTextBox.Value = Settings.refreshRate;
			smtpHostComboBox.Text = Settings.SMTPHost;
			smtpHostPortTextBox.Value = Settings.SMTPPort;
			smtpUsrTextBox.Text = Settings.SMTPUsr;
			smtpPwdTextBox.Text = Settings.SMTPPwd;
			smtpSSLCheckBox.Checked = Settings.SMTPSSL;
		}

		private void smtpHostComboBox_SelectedValueChanged(object sender, EventArgs e) {
			if (smtpHostInfo.hostInfo.ContainsKey(smtpHostComboBox.Text)) {
				smtpHostPortTextBox.Value = Convert.ToDecimal(smtpHostInfo.hostInfo[smtpHostComboBox.Text][0]);
				smtpSSLCheckBox.Checked = (bool)smtpHostInfo.hostInfo[smtpHostComboBox.Text][1];
			}
		}

		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.senderEmail = senderEmailTextBox.Text;
			Settings.acListUrl = aircraftListTextBox.Text;
			Settings.radarUrl = radarURLTextBox.Text;
			Settings.VRSUsr = VRSUsrTextBox.Text;
			Settings.VRSPwd = VRSPwdTextBox.Text;
			Settings.Lat = latTextBox.Value;
			Settings.Long = longTextBox.Value;
			Settings.timeoutLength = Convert.ToInt32(removalTimeoutTextBox.Value);
			Settings.refreshRate = Convert.ToInt32(refreshTextBox.Value);
			Settings.SMTPHost = smtpHostComboBox.Text;
			Settings.SMTPPort = Convert.ToInt32(smtpHostPortTextBox.Value);
			Settings.SMTPUsr = smtpUsrTextBox.Text;
			Settings.SMTPPwd = smtpPwdTextBox.Text;
			Settings.SMTPSSL = smtpSSLCheckBox.Checked;
		}

		private void saveSettingsButton_Click(object sender, EventArgs e) {
			Close();
		}

		private void gmailLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start("https://www.google.com/settings/security/lesssecureapps");
		}
	}

	public static class smtpHostInfo {
		public static Dictionary<string, object[]> hostInfo = new Dictionary<string, object[]>();
	}
}