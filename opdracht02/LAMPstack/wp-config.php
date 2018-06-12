<?php
/**
 * The base configuration for WordPress
 *
 * The wp-config.php creation script uses this file during the
 * installation. You don't have to use the web site, you can
 * copy this file to "wp-config.php" and fill in the values.
 *
 * This file contains the following configurations:
 *
 * * MySQL settings
 * * Secret keys
 * * Database table prefix
 * * ABSPATH
 *
 * @link https://codex.wordpress.org/Editing_wp-config.php
 *
 * @package WordPress
 */
// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define('DB_NAME', 'testapp');
/** MySQL database username */
define('DB_USER', 'vagrant');
/** MySQL database password */
define('DB_PASSWORD', 'vagrant');
/** MySQL hostname */
define('DB_HOST', 'localhost');
/** Database Charset to use in creating database tables. */
define('DB_CHARSET', 'utf8');
/** The Database Collate type. Don't change this if in doubt. */
define('DB_COLLATE', '');
/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define('AUTH_KEY',         '93H2WH5)4IJwI-LRHPJS[tB=|ytP;2E9AI#7#5D{$1]i08`[rF<O/S0SM|+vDBgE');
define('SECURE_AUTH_KEY',  '@tb%1bl1?:-*;dN1V[ O#pPd?]WL>_M%SI6Bx)P^.92 NTkn:J|o!4Y;5,XR-Nv%');
define('LOGGED_IN_KEY',    '3d}1Q!ER*=yP:=mf[zOS~>o+Y%HHaRrH1eVu{[!<7~X=!o??OGU+DETSI,R|NU2[');
define('NONCE_KEY',        '9IH+Nqq]yj{P-3J1MEA* 19BgvyU<,|M@ELg42~GPoWkpc?`:4|D7ug!`{[] 0pc');
define('AUTH_SALT',        'Lcx+{n%].mb0+ f:UoGMpa.+r&}]-R+uK@p2*B)(`/W2BF59@5u|cR}Ub| 3cL|Y');
define('SECURE_AUTH_SALT', 'D_NV5f~5/Ks}Y.`yUOg+M Q?_~1-m:!d`PHfPG{+iaJi&,]vC@N=A9Mf608Xj][7');
define('LOGGED_IN_SALT',   ' #6w8jU`~@rlCE`vGCPtg3b&Y=DQRkMzcJ.~iLUo=0.wX;Qy6j-x@Y+|sg1D-|%n');
define('NONCE_SALT',       'MGR&R.Q61s48q?LKb,!esrLwXP{6-w+A_ys6I;Mc}?:xB:o=-?Yr8-n<(3UpGMlD');
/**#@-*/
/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each
 * a unique prefix. Only numbers, letters, and underscores please!
 */
$table_prefix  = 'wp_';
/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 *
 * For information on other constants that can be used for debugging,
 * visit the Codex.
 *
 * @link https://codex.wordpress.org/Debugging_in_WordPress
 */
define('WP_DEBUG', false);
/* That's all, stop editing! Happy blogging. */
/** Absolute path to the WordPress directory. */
if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');
/** Sets up WordPress vars and included files. */
require_once(ABSPATH . 'wp-settings.php');