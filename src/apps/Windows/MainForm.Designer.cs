using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace Windows;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        #region BlazorWebViewLogic
        this.blazorWebView = new BlazorWebView();

        this.blazorWebView.Anchor =
            ((System.Windows.Forms.AnchorStyles) ((
                (System.Windows.Forms.AnchorStyles.Top 
                 | System.Windows.Forms.AnchorStyles.Left)
                 | System.Windows.Forms.AnchorStyles.Right)));
        this.blazorWebView.Location = new System.Drawing.Point(13, 13);
        this.blazorWebView.Name = "blazorWebView";
        this.blazorWebView.Size = new System.Drawing.Size(775, 162);
        this.blazorWebView.TabIndex = 20;
        this.Controls.Add(blazorWebView);
        #endregion

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";
    }

    #endregion

    private BlazorWebView blazorWebView;
}