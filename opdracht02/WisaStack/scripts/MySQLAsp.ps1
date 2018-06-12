Set-ExecutionPolicy Unrestricted 

#voor de rechten van choco 
chocolatey feature enable -n=allowGlobalConfirmation

#install mysql

choco installmysql 

choco upgrade mysql

#install aspnet

choco install aspnet5
 
