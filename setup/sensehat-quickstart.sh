# Script parameters

declare dotnetVersion="5.0.100-rc.2.20479.15"

# Text formatting
declare red=`tput setaf 1`
declare green=`tput setaf 2`
declare yellow=`tput setaf 3`
declare blue=`tput setaf 4`
declare magenta=`tput setaf 5`
declare cyan=`tput setaf 6`
declare white=`tput setaf 7`
declare defaultColor=`tput setaf 9`
declare bold=`tput bold`
declare plain=`tput sgr0`
declare newline=$'\n'

# Element styling
declare azCliCommandStyle="${plain}${cyan}"
declare defaultTextStyle="${plain}${white}"
declare dotnetCliCommandStyle="${plain}${magenta}"
declare dotnetSayStyle="${magenta}${bold}"
declare headingStyle="${white}${bold}"
declare successStyle="${green}${bold}"
declare warningStyle="${yellow}${bold}"
declare errorStyle="${red}${bold}"

echo
echo
echo "${headingStyle}.NET IoT Libraries Sense HAT quickstart${defaultTextStyle}"
echo
echo Installing .NET SDK v$dotnetVersion...
echo

declare installCmd="curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --version $dotnetVersion"
echo "> ${yellow}$installCmd${defaultTextStyle}"
echo
eval $installCmd
echo

declare iotBits="https://github.com/dotnet/iot"
declare cloneCmd="git clone $iotBits dotnet-iot"
cd ~
echo Downloading from $iotBits...
echo
echo "> ${yellow}$cloneCmd${defaultTextStyle}"
echo
eval $cloneCmd
echo

cd ~/dotnet-iot/src/devices/SenseHat/samples
declare buildCmd="dotnet build"
echo Building SenseHat.Sample...
echo 
echo "> ${dotnetCliCommandStyle}$buildCmd${defaultTextStyle}"
echo 
eval $buildCmd
echo 

declare runCmd="dotnet run"
echo Running SenseHat.Sample...
echo 
echo "> ${dotnetCliCommandStyle}$runCmd${defaultTextStyle}"
echo 
eval $runCmd
echo 
