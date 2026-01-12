<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Buyer.ascx.cs" Inherits="SilkERP360.UI.WPMS.Customer" %>
<script src="Scripts/Buyer.js" type="text/javascript"></script>
<style type="text/css">


.command_button_enabled {
	-moz-box-shadow:inset 0px 1px 0px 0px #caefab;
	-webkit-box-shadow:inset 0px 1px 0px 0px #caefab;
	box-shadow:inset 0px 1px 0px 0px #caefab;
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #77d42a), color-stop(1, #5cb811) );
	background:-moz-linear-gradient( center top, #77d42a 5%, #5cb811 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#77d42a', endColorstr='#5cb811');
	background-color:#77d42a;
	-webkit-border-top-left-radius:0px;
	-moz-border-radius-topleft:0px;
	border-top-left-radius:0px;
	-webkit-border-top-right-radius:0px;
	-moz-border-radius-topright:0px;
	border-top-right-radius:0px;
	-webkit-border-bottom-right-radius:0px;
	-moz-border-radius-bottomright:0px;
	border-bottom-right-radius:0px;
	-webkit-border-bottom-left-radius:0px;
	-moz-border-radius-bottomleft:0px;
	border-bottom-left-radius:0px;
	text-indent:0;
	border:1px solid #268a16;
	display:inline-block;
	color:#306108;
	font-family:Arial Black;
	font-size:15px;
	font-weight:bold;
	font-style:normal;
	height:30px;
	line-height:30px;
	width:120px;
	text-decoration:none;
	text-align:center;
	text-shadow:1px 1px 0px #aade7c;
}
.command_button_disabled {
	-moz-box-shadow:inset 0px 1px 0px 0px #ffffff;
	-webkit-box-shadow:inset 0px 1px 0px 0px #ffffff;
	box-shadow:inset 0px 1px 0px 0px #ffffff;
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ededed), color-stop(1, #dfdfdf) );
	background:-moz-linear-gradient( center top, #ededed 5%, #dfdfdf 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#ededed', endColorstr='#dfdfdf');
	background-color:#ededed;
	-webkit-border-top-left-radius:6px;
	-moz-border-radius-topleft:6px;
	border-top-left-radius:6px;
	-webkit-border-top-right-radius:6px;
	-moz-border-radius-topright:6px;
	border-top-right-radius:6px;
	-webkit-border-bottom-right-radius:6px;
	-moz-border-radius-bottomright:6px;
	border-bottom-right-radius:6px;
	-webkit-border-bottom-left-radius:6px;
	-moz-border-radius-bottomleft:6px;
	border-bottom-left-radius:6px;
	text-indent:0;
	border:1px solid #dcdcdc;
	display:inline-block;
	color:#777777;
	font-family:Arial Black;
	font-size:15px;
	font-weight:bold;
	font-style:normal;
	height:30px;
	line-height:30px;
	width:120px;
	text-decoration:none;
	text-align:center;
	text-shadow:1px 1px 0px #ffffff;
}
    .style1
    {
        width: 50%;
        height: 40px;
    }
    .style2
    {
        width: 0%;
        height: 40px;
    }
</style>

<div id="dvItemConfig" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="background-color:Gray; padding:2px; text-align:center; margin:2px;" 
                class="style1">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="padding:2px; text-align:center;margin:2px;" class="style2">
                &nbsp;
            </td>
            <td style="background-color:Gray; padding:2px; text-align:center;margin-left:1px;" 
                class="style1">
                <div id="dvData" style="display:none; color:White;">
                    <%--<span id="spnData" style=" font-family:Times New Roman; font-size:14px; font-weight:500; color:Aqua;"></span>--%>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
<div id="tbpCustomerRegistration" style=" width:100%; height:100%;">
<div style="width:100%; height:auto; text-align:center; margin:0 auto;">
                               
                                     <table class="table_ip_control_container" cellpadding="2px" cellspacing="2px" style="width:50%; margin:0 auto;">
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Country :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                    <asp:DropDownList ID="Country" runat="server" Width="99%" ClientIDMode="Static" 
                                                       >
                                                    <asp:ListItem Value="0">.....Select The Country.....</asp:ListItem>
                                                        <asp:ListItem>Afghanistan</asp:ListItem>
                                                        <asp:ListItem>Albania</asp:ListItem>
                                                        <asp:ListItem>Algeria</asp:ListItem>
                                                        <asp:ListItem>American Samoa</asp:ListItem>
                                                        <asp:ListItem>Andorra</asp:ListItem>
                                                        <asp:ListItem>Angola</asp:ListItem>
                                                        <asp:ListItem>Anguilla</asp:ListItem>
                                                        <asp:ListItem> Antarctica</asp:ListItem>
                                                        <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                                                        <asp:ListItem>Argentina</asp:ListItem>
                                                        <asp:ListItem>Armenia</asp:ListItem>
                                                        <asp:ListItem>Aruba</asp:ListItem>
                                                        <asp:ListItem>Australia</asp:ListItem>
                                                        <asp:ListItem>Austria</asp:ListItem>
                                                        <asp:ListItem>Azerbaijan</asp:ListItem>
                                                        <asp:ListItem> Bahamas</asp:ListItem>
                                                        <asp:ListItem>Bahrain</asp:ListItem>
                                                        <asp:ListItem>Bangladesh</asp:ListItem>
                                                        <asp:ListItem>Barbados</asp:ListItem>
                                                        <asp:ListItem> Belarus</asp:ListItem>
                                                        <asp:ListItem>Belgium</asp:ListItem>
                                                        <asp:ListItem>Belize</asp:ListItem>
                                                        <asp:ListItem>Benin</asp:ListItem>
                                                        <asp:ListItem>Bermuda</asp:ListItem>
                                                        <asp:ListItem>Bhutan</asp:ListItem>
                                                        <asp:ListItem>Bolivia</asp:ListItem>
                                                        <asp:ListItem>Bosnia and Herzegovina</asp:ListItem>
                                                        <asp:ListItem>Botswana</asp:ListItem>
                                                        <asp:ListItem>Brazil</asp:ListItem>
                                                        <asp:ListItem>Brunei Darussalam</asp:ListItem>
                                                        <asp:ListItem>Bulgaria</asp:ListItem>
                                                        <asp:ListItem>Burkina Faso</asp:ListItem>
                                                        <asp:ListItem>Burundi</asp:ListItem>
                                                        <asp:ListItem>Cambodia</asp:ListItem>
                                                        <asp:ListItem>Cameroon</asp:ListItem>
                                                        <asp:ListItem>Canada</asp:ListItem>
                                                        <asp:ListItem>Cape Verde</asp:ListItem>
                                                        <asp:ListItem>Cayman Islands</asp:ListItem>
                                                        <asp:ListItem>Central African Republic</asp:ListItem>
                                                        <asp:ListItem>Chad</asp:ListItem>
                                                        <asp:ListItem>Chile</asp:ListItem>
                                                        <asp:ListItem>China</asp:ListItem>
                                                        <asp:ListItem>Christmas Island</asp:ListItem>
                                                        <asp:ListItem>Cocos (Keeling) Islands</asp:ListItem>
                                                        <asp:ListItem>Colombia</asp:ListItem>
                                                        <asp:ListItem>Comoros</asp:ListItem>
                                                        <asp:ListItem>Democratic Republic of the Congo (Kinshasa)</asp:ListItem>
                                                        <asp:ListItem>Congo, Republic of (Brazzaville)</asp:ListItem>
                                                        <asp:ListItem> Cook Islands</asp:ListItem>
                                                        <asp:ListItem>Costa Rica</asp:ListItem>
                                                        <asp:ListItem>Ivory Coast</asp:ListItem>
                                                        <asp:ListItem>Croatia</asp:ListItem>
                                                        <asp:ListItem>Cuba</asp:ListItem>
                                                        <asp:ListItem>Cyprus</asp:ListItem>
                                                        <asp:ListItem>Czech Republic</asp:ListItem>
                                                        <asp:ListItem>Denmark</asp:ListItem>
                                                        <asp:ListItem>Djibouti</asp:ListItem>
                                                        <asp:ListItem>Dominica</asp:ListItem>
                                                        <asp:ListItem>Dominican Republic</asp:ListItem>
                                                        <asp:ListItem>East Timor (Timor-Leste)</asp:ListItem>
                                                        <asp:ListItem>Ecuador</asp:ListItem>
                                                        <asp:ListItem>Egypt</asp:ListItem>
                                                        <asp:ListItem>El Salvador</asp:ListItem>
                                                        <asp:ListItem>Equatorial Guinea</asp:ListItem>
                                                        <asp:ListItem>Eritrea</asp:ListItem>
                                                        <asp:ListItem Value="Estonia">Estonia</asp:ListItem>
                                                        <asp:ListItem>Ethiopia</asp:ListItem>
                                                        <asp:ListItem>Falkland Islands</asp:ListItem>
                                                        <asp:ListItem>Faroe Islands</asp:ListItem>
                                                        <asp:ListItem>Fiji</asp:ListItem>
                                                        <asp:ListItem>Finland</asp:ListItem>
                                                        <asp:ListItem>France</asp:ListItem>
                                                        <asp:ListItem>French Guiana</asp:ListItem>
                                                        <asp:ListItem>French Polynesia</asp:ListItem>
                                                        <asp:ListItem>French Southern Territories</asp:ListItem>
                                                        <asp:ListItem>Gabon</asp:ListItem>
                                                        <asp:ListItem>Gambia</asp:ListItem>
                                                        <asp:ListItem>Georgia</asp:ListItem>
                                                        <asp:ListItem>Germany</asp:ListItem>
                                                        <asp:ListItem>Ghana</asp:ListItem>
                                                        <asp:ListItem>Gibraltar</asp:ListItem>
                                                        <asp:ListItem>Great Britain</asp:ListItem>
                                                        <asp:ListItem>Greece</asp:ListItem>
                                                        <asp:ListItem>Greenland</asp:ListItem>
                                                        <asp:ListItem>Grenada</asp:ListItem>
                                                        <asp:ListItem>Guadeloupe</asp:ListItem>
                                                        <asp:ListItem>Guam</asp:ListItem>
                                                        <asp:ListItem>Guatemala</asp:ListItem>
                                                        <asp:ListItem>Guinea-Bissau</asp:ListItem>
                                                        <asp:ListItem>Guyana</asp:ListItem>
                                                        <asp:ListItem>Haiti</asp:ListItem>
                                                        <asp:ListItem>Holy See</asp:ListItem>
                                                        <asp:ListItem>Honduras</asp:ListItem>
                                                        <asp:ListItem>Hong Kong</asp:ListItem>
                                                        <asp:ListItem>Hungary</asp:ListItem>
                                                        <asp:ListItem>Iceland</asp:ListItem>
                                                        <asp:ListItem Value="India">India</asp:ListItem>
                                                        <asp:ListItem>Indonesia</asp:ListItem>
                                                        <asp:ListItem>Iran (Islamic Republic of)</asp:ListItem>
                                                        <asp:ListItem>Iraq</asp:ListItem>
                                                        <asp:ListItem>Ireland</asp:ListItem>
                                                        <asp:ListItem>Italy</asp:ListItem>
                                                        <asp:ListItem>Jamaica</asp:ListItem>
                                                        <asp:ListItem>Japan</asp:ListItem>
                                                        <asp:ListItem>Jordan</asp:ListItem>
                                                        <asp:ListItem>Kazakhstan</asp:ListItem>
                                                        <asp:ListItem>Kenya</asp:ListItem>
                                                        <asp:ListItem>Kiribati</asp:ListItem>
                                                        <asp:ListItem>Korea, Democratic People&#39;s Rep. (North Korea)</asp:ListItem>
                                                        <asp:ListItem>Korea, Republic of (South Korea)</asp:ListItem>
                                                        <asp:ListItem>Kosovo</asp:ListItem>
                                                        <asp:ListItem>Kuwait</asp:ListItem>
                                                        <asp:ListItem>Kyrgyzstan</asp:ListItem>
                                                        <asp:ListItem>Lao, People&#39;s Democratic Republic</asp:ListItem>
                                                        <asp:ListItem>Latvia</asp:ListItem>
                                                        <asp:ListItem>Lebanon</asp:ListItem>
                                                        <asp:ListItem>Lesotho</asp:ListItem>
                                                        <asp:ListItem>Liberia</asp:ListItem>
                                                        <asp:ListItem>Libya</asp:ListItem>
                                                        <asp:ListItem Value="Liechtenstein">Liechtenstein</asp:ListItem>
                                                        <asp:ListItem>Lithuania</asp:ListItem>
                                                        <asp:ListItem>Luxembourg</asp:ListItem>
                                                        <asp:ListItem>Macau</asp:ListItem>
                                                        <asp:ListItem>Macedonia, Rep. of</asp:ListItem>
                                                        <asp:ListItem>Madagascar</asp:ListItem>
                                                        <asp:ListItem>Malawi</asp:ListItem>
                                                        <asp:ListItem>Malaysia</asp:ListItem>
                                                        <asp:ListItem>Maldives</asp:ListItem>
                                                        <asp:ListItem>Mali</asp:ListItem>
                                                        <asp:ListItem>Malta</asp:ListItem>
                                                        <asp:ListItem Value="Marshall Islands"></asp:ListItem>
                                                        <asp:ListItem>Martinique</asp:ListItem>
                                                        <asp:ListItem>Mauritania</asp:ListItem>
                                                        <asp:ListItem>Mauritius</asp:ListItem>
                                                        <asp:ListItem>Mayotte</asp:ListItem>
                                                        <asp:ListItem>Mexico</asp:ListItem>
                                                        <asp:ListItem>Micronesia, Federal States of</asp:ListItem>
                                                        <asp:ListItem>Moldova, Republic of</asp:ListItem>
                                                        <asp:ListItem>Monaco</asp:ListItem>
                                                        <asp:ListItem>Mongolia</asp:ListItem>
                                                        <asp:ListItem>Montenegro</asp:ListItem>
                                                        <asp:ListItem>Montserrat</asp:ListItem>
                                                        <asp:ListItem>Morocco</asp:ListItem>
                                                        <asp:ListItem>Mozambique</asp:ListItem>
                                                        <asp:ListItem Value="Myanmar, Burma"></asp:ListItem>
                                                        <asp:ListItem>Namibia</asp:ListItem>
                                                        <asp:ListItem>Nauru</asp:ListItem>
                                                        <asp:ListItem>Nepal</asp:ListItem>
                                                        <asp:ListItem>Netherlands</asp:ListItem>
                                                        <asp:ListItem>Netherlands Antilles</asp:ListItem>
                                                        <asp:ListItem>New Caledonia</asp:ListItem>
                                                        <asp:ListItem>New Zealand</asp:ListItem>
                                                        <asp:ListItem>Nicaragua</asp:ListItem>
                                                        <asp:ListItem>Niger</asp:ListItem>
                                                        <asp:ListItem>Nigeria</asp:ListItem>
                                                        <asp:ListItem>Niue</asp:ListItem>
                                                        <asp:ListItem>Northern Mariana Islands</asp:ListItem>
                                                        <asp:ListItem>Norway</asp:ListItem>
                                                        <asp:ListItem>Oman</asp:ListItem>
                                                        <asp:ListItem>Pakistan</asp:ListItem>
                                                        <asp:ListItem>Palau</asp:ListItem>
                                                        <asp:ListItem Value="Palestinian territories"></asp:ListItem>
                                                        <asp:ListItem>Panama</asp:ListItem>
                                                        <asp:ListItem>Papua New Guinea</asp:ListItem>
                                                        <asp:ListItem>Paraguay</asp:ListItem>
                                                        <asp:ListItem>Peru</asp:ListItem>
                                                        <asp:ListItem Value="Philippines"></asp:ListItem>
                                                        <asp:ListItem>Pitcairn Island</asp:ListItem>
                                                        <asp:ListItem>Poland</asp:ListItem>
                                                        <asp:ListItem>Portugal</asp:ListItem>
                                                        <asp:ListItem>Puerto Rico</asp:ListItem>
                                                        <asp:ListItem>Qatar</asp:ListItem>
                                                        <asp:ListItem>Reunion Island</asp:ListItem>
                                                        <asp:ListItem>Romania</asp:ListItem>
                                                        <asp:ListItem>Russian Federation</asp:ListItem>
                                                        <asp:ListItem>Rwanda</asp:ListItem>
                                                        <asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
                                                        <asp:ListItem>Saint Lucia</asp:ListItem>
                                                        <asp:ListItem>Saint Vincent and the Grenadines</asp:ListItem>
                                                        <asp:ListItem>Samoa</asp:ListItem>
                                                        <asp:ListItem>San Marino</asp:ListItem>
                                                        <asp:ListItem>Sao Tome and Principe</asp:ListItem>
                                                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                                                        <asp:ListItem>Senegal</asp:ListItem>
                                                        <asp:ListItem Value="Serbia"></asp:ListItem>
                                                        <asp:ListItem Value="Seychelles"></asp:ListItem>
                                                        <asp:ListItem>Sierra Leone</asp:ListItem>
                                                        <asp:ListItem Value="Singapore"></asp:ListItem>
                                                        <asp:ListItem Value="Slovakia (Slovak Republic)"></asp:ListItem>
                                                        <asp:ListItem>Slovenia</asp:ListItem>
                                                        <asp:ListItem>Solomon Islands</asp:ListItem>
                                                        <asp:ListItem>Somalia</asp:ListItem>
                                                        <asp:ListItem>South Africa</asp:ListItem>
                                                        <asp:ListItem>South Sudan</asp:ListItem>
                                                        <asp:ListItem>Spain</asp:ListItem>
                                                        <asp:ListItem>Sri Lanka</asp:ListItem>
                                                        <asp:ListItem>Sudan</asp:ListItem>
                                                        <asp:ListItem>Suriname</asp:ListItem>
                                                        <asp:ListItem>Swaziland</asp:ListItem>
                                                        <asp:ListItem>Sweden</asp:ListItem>
                                                        <asp:ListItem Value="Switzerland"></asp:ListItem>
                                                        <asp:ListItem>Syria, Syrian Arab Republic</asp:ListItem>
                                                        <asp:ListItem>Taiwan (Republic of China)</asp:ListItem>
                                                        <asp:ListItem Value="Tajikistan"></asp:ListItem>
                                                        <asp:ListItem>Tanzania; officially the United Republic of Tanzania</asp:ListItem>
                                                        <asp:ListItem>Thailand</asp:ListItem>
                                                        <asp:ListItem>Tibet</asp:ListItem>
                                                        <asp:ListItem>Timor-Leste (East Timor)</asp:ListItem>
                                                        <asp:ListItem>Togo</asp:ListItem>
                                                        <asp:ListItem>Tokelau</asp:ListItem>
                                                        <asp:ListItem Value="Tonga"></asp:ListItem>
                                                        <asp:ListItem Value="Trinidad and Tobago"></asp:ListItem>
                                                        <asp:ListItem Value="Tunisia"></asp:ListItem>
                                                        <asp:ListItem>Turkey</asp:ListItem>
                                                        <asp:ListItem>Turkmenistan</asp:ListItem>
                                                        <asp:ListItem>Turks and Caicos Islands</asp:ListItem>
                                                        <asp:ListItem>Tuvalu</asp:ListItem>
                                                        <asp:ListItem Value="Uganda"></asp:ListItem>
                                                        <asp:ListItem>Ukraine</asp:ListItem>
                                                        <asp:ListItem>United Arab Emirates</asp:ListItem>
                                                        <asp:ListItem>United Kingdom</asp:ListItem>
                                                        <asp:ListItem>United States</asp:ListItem>
                                                        <asp:ListItem>Uruguay</asp:ListItem>
                                                        <asp:ListItem>Uzbekistan</asp:ListItem>
                                                        <asp:ListItem>Vanuatu</asp:ListItem>
                                                        <asp:ListItem>Vatican City State (Holy See)</asp:ListItem>
                                                        <asp:ListItem>Venezuela</asp:ListItem>
                                                        <asp:ListItem>Vietnam</asp:ListItem>
                                                        <asp:ListItem>Virgin Islands (British)</asp:ListItem>
                                                        <asp:ListItem>Virgin Islands (U.S.)</asp:ListItem>
                                                        <asp:ListItem>Wallis and Futuna Islands</asp:ListItem>
                                                        <asp:ListItem>Western Sahara</asp:ListItem>
                                                        <asp:ListItem Value="Yemen"></asp:ListItem>
                                                        <asp:ListItem Value="Zambia">Zambia</asp:ListItem>
                                                        <asp:ListItem>Zimbabwe</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Company :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtCompany_NC" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style=" width:30%;">
                                                        <label>Contact Person :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtContactPerson_NC" runat="server" Width="100%" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Address :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtAddress_NC" runat="server" TextMode="MultiLine" 
                                                            Width="100%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Phone :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtPhone_NC" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                      
                                               <tr>
                                                    <td style=" width:30%;">
                                                        <label>Email :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="Email" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;"><br />
                                                        <a class='command_button_enabled' id='A3'
                                                            onclick="CustomerSave(); return false;" href='#'>Save</a>
                                                    <a class='command_button_enabled' id='A6'onclick="Newcustomer(); return false;" 
                                                            href='#'>New</a>
                                                    
                                                    </td>
                                                </tr>
                                            </table>
                                        
                                            <div>
                                <a class='command_button_enabled' id='A7'onclick="LoadCustomerLoad(); return false;" href='#'>All Customer</a>
                                </div>

                                <div>
                                 
                                <div style="width:95%; height:400px; overflow:scroll; border:1px solid blue;">
                                    <div></div>
                                     <table id="CustomerList" class="CSSTableGenerator" width="100%" cellspacing="0">
                                        
                                        <tbody style="height:auto;border:1px solid blue;border-right:1px solid blue;">
                                        </tbody>
                                    </table>
                                </div>

                                <div id="dvItems" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                    <table id="tblItems">
                    </table>
                </div>
</div>
</div>
</div>
                    </div>
                    </td>
                    </tr>
                    </table>
                    
        </div>            
    

