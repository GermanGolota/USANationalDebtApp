# USANationalDebtApp
Application, that allows its users to get partly accurate data about current state of United States federal debt

<h1>Contents:</h1>
</br>
<a href="#First">1) Installation</a>
<br/>
<a href="#Second">2) Design overview</a>
<br/>
<h2 id="First">1 - Installation</h2>
This application can be installed via the docker container:
</br>
1) Download compose file from <a href="https://drive.google.com/file/d/1eihBT-KfiwpFB03HJsV6BRXVUcMicIvH/view?usp=sharing">here</a>
2) Run:
<code>docker-compose up *file-location*</code>
where file-location is the location of the downloaded compose file
</br>
Note: If the SQL Server container have not been able to start up in time for WebAPI container, then WebAPI container would reload and try to connect again
<h2 id="Second">2 - Design overview</h2>
<img src="https://user-images.githubusercontent.com/64675654/105413527-e387fd00-5c3e-11eb-95ca-989a515e7901.png"></img>
