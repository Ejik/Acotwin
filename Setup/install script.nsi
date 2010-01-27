!ifdef HAVE_UPX
!packhdr tmp.dat "upx\upx -9 tmp.dat"
!endif

!ifdef NOCOMPRESS
SetCompress off
!endif

;--------------------------------

Name "AcotSetup"
Caption "Установка АСОТwin"
OutFile "awsetup.exe"

SetDateSave on
SetDatablockOptimize on
CRCCheck on
SilentInstall normal
BGGradient 000000 800000 FFFFFF
InstallColors FF8080 000030
XPStyle on


InstallDir "c:\AcotWin"
InstallDirRegKey HKLM "Software\Acotwin\Acotwin" ""

CheckBitmap "${NSISDIR}\Contrib\Graphics\Checks\classic-cross.bmp"
LoadLanguageFile "${NSISDIR}\Contrib\Language files\Russian.nlf"


;--------------------------------
;Version Information

  VIProductVersion "1.5.1.1"
  VIAddVersionKey /LANG=${LANG_RUSSIAN} "ProductName" "Acotwin"
;  VIAddVersionKey /LANG=${LANG_RUSSIAN} "Comments" "A test comment"
;  VIAddVersionKey /LANG=${LANG_RUSSIAN} "CompanyName" "ACT company"
  VIAddVersionKey /LANG=${LANG_RUSSIAN} "LegalTrademarks" "Комплекс программ Автоматизированная система оплаты труда"
  VIAddVersionKey /LANG=${LANG_RUSSIAN} "LegalCopyright" "Чумак Сергей Николаевич"
  VIAddVersionKey /LANG=${LANG_RUSSIAN} "FileDescription" "Acot for windows"
  VIAddVersionKey /LANG=${LANG_RUSSIAN} "FileVersion" "1.5.3215.18883"



;--------------------------------

Page directory
;Page components
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

!ifndef NOINSTTYPES ; only if not defined
  InstType "Полная"
  InstType "Минимальная"
!endif

AutoCloseWindow false
ShowInstDetails show

;--------------------------------

; The stuff to install
Section "Программные файлы (необходимо)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
SetOutPath $INSTDIR

  File "Acotwin.exe"
  File "AcotWin.exe.config"
  File "AcotWin.exe.manifest"
  File "AboutModule.dll"
  File "CommonDialogsModule.dll"
  File "InfoViewModule.dll"
  File "InfoViewModule.dll.config"
  File "Infrastructure.BootStrap.dll"
  File "Infrastructure.Controls.dll"
  File "Infrastructure.Interface.dll"
  File "Infrastructure.HomeModule.dll"
  File "Infrastructure.Interface.dll.config"
  File "Infrastructure.Library.dll"
  File "Infrastructure.Module.dll"
  File "Infrastructure.Module.dll.config"
  File "ProfileCatalog.xml"
  File "ProfileCatalogOndemand.xml"
  File "ReadOrgModule.dll"
  File "Services.dll"
  File "SettingsModule.dll"
  File "WhatsNew.txt"


  ;File "ChkAddrModule.dll"
  ;File "ChkAddrModule.Interface.dll"

  ;File "Interop.ADODB.dll"
  ;File "Interop.ADOX.dll"
  ;File "Interop.JRO.dll"


  File "Microsoft.Practices.CompositeUI.dll"
  File "Microsoft.Practices.CompositeUI.WinForms.dll"
  File "Microsoft.Practices.EnterpriseLibrary.Common.dll"
  File "Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.dll"
  File "Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.dll"
  File "Microsoft.Practices.EnterpriseLibrary.Logging.dll"
  File "Microsoft.Practices.ObjectBuilder.dll"
  File "Microsoft.Practices.SmartClient.EnterpriseLibrary.dll"


   
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\Acotwin "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Acotwin" "DisplayName" "Acotwin (только удаление)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Acotwin" "UninstallString" '"$INSTDIR\Uninstall.exe"'
  ;WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Acotwin" "NoModify" 1
  ;WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Acotwin" "NoRepair" 1
  WriteUninstaller "Uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Ярлыки в главном меню"
SectionIn 1

  CreateDirectory "$SMPROGRAMS\Acotwin"
  CreateShortCut "$SMPROGRAMS\Acotwin\Удаление.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\Acotwin\Acotwin.lnk" "$INSTDIR\Acotwin.exe" "" "$INSTDIR\Acotwin.exe" 0  
  CreateShortCut "$SMPROGRAMS\Acotwin\Что нового.lnk" "$INSTDIR\WhatsNew.txt" "" "$INSTDIR\WhatsNew.txt" 0  

SectionEnd

Section "Заставки на рабочий стол"
SectionIn 1
  
  ; Set output path to the installation directory.
  CreateDirectory "$INSTDIR\Desktop\" 
  SetOutPath "$INSTDIR\Desktop"
  File "Desktop\Acot.jpg"
  File "Desktop\Calendar2007.jpg"

SectionEnd

Section "Ярлык на рабочий стол"
SectionIn 1

  SetOutPath "$INSTDIR"
  CreateShortCut "$DESKTOP\Acotwin.lnk" "$INSTDIR\Acotwin.exe"

SectionEnd

Section "Файлы справки"
SectionIn 1
  
  ; Set output path to the installation directory.
  CreateDirectory "$INSTDIR\Help\"
  SetOutPath "$INSTDIR\Help"
  File "Help\Книги.chm"
  CreateShortCut "$SMPROGRAMS\Acotwin\Справка.lnk" "$INSTDIR\Help\Книги.chm" "" "$INSTDIR\Help\Книги.chm" 0


SectionEnd
;--------------------------------

; Uninstaller

UninstallText "Удаление Acotwin."

Section "Uninstall"

  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Acotwin"
  DeleteRegKey HKLM "SOFTWARE\Acotwin\"
  Delete "$INSTDIR\AcotWin.exe"

  Delete "$INSTDIR\uninstall.exe"

  Delete "$INSTDIR\Help\Книги.chm"  

  Delete "$INSTDIR\Desktop\Acot.jpg"
  Delete "$INSTDIR\Desktop\Calendar2007.jpg"

  Delete "$INSTDIR\Acotwin.exe"
  Delete "$INSTDIR\AcotWin.exe.config"
  Delete "$INSTDIR\AcotWin.exe.manifest"
  Delete "$INSTDIR\AboutModule.dll"
  Delete "$INSTDIR\CommonDialogsModule.dll"
  Delete "$INSTDIR\InfoViewModule.dll"
  Delete "$INSTDIR\InfoViewModule.dll.config"
  Delete "$INSTDIR\Infrastructure.BootStrap.dll"
  Delete "$INSTDIR\Infrastructure.Controls.dll"
  Delete "$INSTDIR\Infrastructure.Interface.dll"
  Delete "$INSTDIR\Infrastructure.HomeModule.dll"
  Delete "$INSTDIR\Infrastructure.Interface.dll.config"
  Delete "$INSTDIR\Infrastructure.Library.dll"
  Delete "$INSTDIR\Infrastructure.Module.dll"
  Delete "$INSTDIR\Infrastructure.Module.dll.config"
  Delete "$INSTDIR\ProfileCatalog.xml"
  Delete "$INSTDIR\ProfileCatalogOndemand.xml"
  Delete "$INSTDIR\ReadOrgModule.dll"
  Delete "$INSTDIR\Services.dll"
  Delete "$INSTDIR\SettingsModule.dll"
  Delete "$INSTDIR\WhatsNew.txt"

  Delete "$INSTDIR\Microsoft.Practices.CompositeUI.dll"
  Delete "$INSTDIR\Microsoft.Practices.CompositeUI.WinForms.dll"
  Delete "$INSTDIR\Microsoft.Practices.EnterpriseLibrary.Common.dll"
  Delete "$INSTDIR\Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.dll"
  Delete "$INSTDIR\Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.dll"
  Delete "$INSTDIR\Microsoft.Practices.EnterpriseLibrary.Logging.dll"
  Delete "$INSTDIR\Microsoft.Practices.ObjectBuilder.dll"
  Delete "$INSTDIR\Microsoft.Practices.SmartClient.EnterpriseLibrary.dll"


  Delete "$SMPROGRAMS\Acotwin\*.*"
  Delete "$DESKTOP\Acotwin.lnk"	
  RMDir "$SMPROGRAMS\Acotwin"
  RMDir "$INSTDIR\Help"
  RMDir "$INSTDIR\Desktop"    
  RMDir "$INSTDIR"

  RMDir /r "$LOCALAPPDATA\ACT"
  
  IfFileExists "$INSTDIR" 0 NoErrorMsg
    MessageBox MB_OK "Сообщение: $INSTDIR не может быть уничтожена!" IDOK 0 ; skipped if file doesn't exist
  NoErrorMsg:

SectionEnd






