:: Query the Client container
cls
@echo off

ECHO Results from the Curl Page showing Client and Server Hostname/IP differences
ECHO ----------------------------------------------------------------------------
ECHO.
FOR %%A IN (1 2 3 4 5) DO (
	
	ECHO Query #%%A

	curl localhost:9900/curl
	ECHO.
	ECHO.
)
@echo on