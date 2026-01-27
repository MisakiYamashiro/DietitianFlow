<%@ Page Title="" Language="C#" MasterPageFile="~/MisakiHealthCenter.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ParaAvcilariObezlerMerkezi.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dashboard-row">

        <div class="stats-column">
            <div class="card">
                <img src="Image/CALENDAR.png" alt="Bekleyen Randevular" />
                <div class="card-text">
                    <label>Bekleyen Randevular</label>
                    <br />
                    <asp:Label ID="lbl_bekleyenRandevuSayi" runat="server" Text="1" CssClass="count-text"></asp:Label>
                </div>
            </div>

            <div class="card">
                <img src="Image/calendarstar.png" alt="Yaklaşan Randevular" />
                <div class="card-text">
                    <label>Yaklaşan Randevular</label>
                    <br />
                    <asp:Label ID="lbl_yaklasanrandevular" runat="server" Text="1" CssClass="count-text"></asp:Label>
                </div>
            </div>

            <div class="card">
                <img src="Image/patients.png" alt="Aktif Hastalar" />
                <div class="card-text">
                    <label>Aktif Hastalar</label>
                    <br />
                    <asp:Label ID="lbl_aktifhastalar" runat="server" Text="1" CssClass="count-text"></asp:Label>
                </div>
            </div>
        </div>

        <div class="cardChart">
            <div class="chart-wrapper">
                <h3>Appointments Chart</h3>
                <canvas id="randevuChart"></canvas>
            </div>
        </div>

    </div>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        var tarihler = <%= JsonLabels %>;
        var sayilar = <%= JsonData %>;

        if (tarihler && tarihler.length > 0) {
            var ctx = document.getElementById('randevuChart').getContext('2d');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: tarihler,
                    datasets: [{
                        label: 'Aktif Randevular',
                        data: sayilar,
                        backgroundColor: 'rgba(75, 192, 192, 0.6)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1,
                        borderRadius: 4
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: { display: false }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            ticks: { stepSize: 1 }
                        }
                    }
                }
            });
        } else {
            document.getElementById('randevuChart').parentElement.innerHTML = "<p style='text-align:center; padding-top:100px; color:#666;'>Henüz randevu verisi yok.</p>";
        }
    </script>

</asp:Content>