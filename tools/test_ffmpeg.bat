@echo off
SET ROOT_DIR=%~dp0..\
PUSHD "%ROOT_DIR%"

SET OUTPUT_DIR=tools\tmp
SET OUTPUT=%OUTPUT_DIR%\test_ffmpeg.flv
SET VIDEO=SCFF DirectShow Filter
SET AUDIO=Mixer (Realtek High Definition 
SET FFMPEG_EXE=ext\ffmpeg\x64\bin\ffmpeg.exe

MKDIR "%OUTPUT_DIR%"
DEL "%OUTPUT%"

REM [TUNED]
"%FFMPEG_EXE%" -rtbufsize 100MB -f dshow -framerate 30 -video_size 640x360 -pixel_format yuv420p -i video="%VIDEO%":audio="%AUDIO%" -maxrate 1200k -bufsize 2400k -crf 23 -qmin 10 -qmax 51 -vcodec libx264 -preset medium -x264opts b-adapt=2:direct=auto:keyint=300:me=umh:rc-lookahead=50:ref=6:subme=5  -acodec aac -ar 48000 -ab 96k -ac 2 -vol 256 -threads 4 -metadata maxBitrate="1200k" -f flv "%OUTPUT%"
"%OUTPUT%"

REM [SIMPLE]
REM "%FFMPEG_EXE%" -rtbufsize 100MB -f dshow -framerate 30 -video_size 640x360 -pixel_format yuv420p -i video="%VIDEO%":audio="%AUDIO%" -maxrate 700k -bufsize 1400k -crf 30 -vcodec libx264 -preset slow -profile:v main -acodec aac -ar 48000 -ab 96k -ac 2 -vol 256 -threads 4 -metadata maxBitrate="700k" -f flv "%OUTPUT%"
REM "%OUTPUT%"

POPD