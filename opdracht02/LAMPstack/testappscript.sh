#!/bin/bash

databaseName='testapp'
mysqlRootPass='TestApp95'

mysql -uroot -p${mysqlRootPass} << EOF
CREATE TABLE IF NOT EXISTS $databaseName.Users (
  id int(11) unsigned NOT NULL AUTO_INCREMENT,
  name varchar(50) NOT NULL DEFAULT '',
  email varchar(120) NOT NULL DEFAULT '',
  country varchar(50) DEFAULT 'USA',
  password varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (id)
) AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
EOF
cd ~
wget http://wordpress.org/latest.tar.gz
tar xzvf latest.tar.gz
rsync -avP ~/wordpress/ /var/www/html/
mkdir /var/www/html/wp-content/uploads
chown -R apache:apache /var/www/html/*
cp /vagrant/wp-config.php wp-config.php