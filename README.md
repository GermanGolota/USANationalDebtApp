# USANationalDebtApp
Application, that allows its users to get partly accurate data about current state of United States federal debt

<h1 id="Content">Contents:</h1>
</br>
<a href="#First">1) Installation</a>
<br/>
<a href="#Second">2) Design overview</a>
<br/>
<a href="#Third">3) Technologies used</a>
<br/>
<a href="#Fourth">4) UI Overview</a>
<br/>
<a href="#Content"><h2 id="First">1 - Installation</h2></a>
This application can be installed via the docker container:
</br>
1) Download compose file from <a href="https://drive.google.com/file/d/1eihBT-KfiwpFB03HJsV6BRXVUcMicIvH/view?usp=sharing">here</a>
</br>
2)Navigate to folder, that contains downloaded file
</br>
3) Run:
<code>docker-compose up</code>
</br>
<strong>
  Note: If the SQL Server container have not been able to start up in time for WebAPI container, then WebAPI container would reload and try to connect again
</strong>
</br>
As result of the installation a UI project would be run on local machine on port 8080 and WebAPI would be listening on ports 44333 and 44334
</br>

<strong>
  Note: Those settings can be changed in docker-compose.yaml file
</strong>
</br>
<a href="#Content"><h2 id="Second">2 - Design overview</h2></a>
<img src="https://user-images.githubusercontent.com/64675654/105480719-c3902200-5cae-11eb-9998-58d888278ecc.png"></img>
<a href="#Content"><h2 id="Third">3 - Technologies used</h2></a>
<ul>
<li>DB – Entity Framework Core with MSSQL Server</li>
<li>Web API – ASP.NET Core</li>
<li>Web UI – Blazor WebAssembly</li>
<li>Deployment - Docker</li>
</ul>
<a href="#Content"><h2 id="Fourth">4 - UI Overview</h2></a>
<img src="https://user-images.githubusercontent.com/64675654/105481291-84160580-5caf-11eb-8351-65582845e90e.png"></img>


