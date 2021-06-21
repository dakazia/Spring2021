
LogParser "SELECT Text AS All_ERROR_MESSAGE: FROM ..\BrainstormSessions\bin\Debug\netcoreapp3.0\Logs\*.log WHERE Text LIKE '%%ERROR%%'" -i:TEXTLINE -o:CSV >> .\Report1.log
LogParser "SELECT COUNT(TEXT) AS Number_of_ERROR: FROM ..\BrainstormSessions\bin\Debug\netcoreapp3.0\Logs\*.log WHERE Text LIKE '%%ERROR%%%%'" -i:TEXTLINE -o:CSV >> .\Report1.log
LogParser "SELECT substr(text, 24, 5), COUNT(*) AS Level FROM ..\BrainstormSessions\bin\Debug\netcoreapp3.0\Logs\*.log GROUP BY substr(text, 24, 5)" -i:TEXTLINE -o:CSV >> .\Report1.log

pause