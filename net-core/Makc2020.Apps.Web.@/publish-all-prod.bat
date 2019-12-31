@echo off

echo Publish all prod start

publish-client "--configuration=production" & ^
publish-server-release & ^
echo Publish all prod finish & ^
title Publish all prod