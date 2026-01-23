<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ParaAvcilariObezlerMerkezi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>DietitianFlow - Giriş</title>
    
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet" />
    <link href="Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="page-logo">
            <img src="Image/DietitianFlow.png" alt="DietitianFlow Logo" />
        </div>

        <div class="login-container">
            <div class="login-card">
                
                <div class="header-text">
                    <h1>DietitianFlow</h1>
                    <p>Hoş geldiniz, lütfen giriş yapın.</p>
                </div>

                <div class="form-group">
                    <label>E-Posta</label>
                    <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" Placeholder="ornek@email.com" TextMode="Email"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Şifre</label>
                    <asp:TextBox ID="tb_password" runat="server" CssClass="form-control" TextMode="Password" Placeholder="••••••"></asp:TextBox>
                </div>

                <div class="button-area">
                    <asp:Button ID="btn_login" runat="server" Text="Giriş Yap" CssClass="btn-primary"  OnClick="btn_login_Click"/>
                </div>
                
                <div class="footer-links">
                    <a href="#">Şifremi Unuttum?</a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>