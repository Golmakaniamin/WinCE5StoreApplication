#ifndef _PRN_DLL_H_
#define _PRN_DLL_H_

#define _DLL_EXPORT_  extern "C" __declspec (dllexport)

#define BLACKMARK

typedef struct PRINTERINFO{
	UINT	Feed;			//
	UINT	Align;			//
	UINT	Underlinesize;	//	
	UINT	BarCodeWidth;	//
	UINT	BarCodeHeight;	//
	UINT	BarCodeTextPos;	//
	UINT	Spacing;		//
	BOOL	Smallfont;		//
	BOOL	Width;			//
	BOOL	Height;			//
	BOOL	Bold;			//	
	BOOL	Rotate;			//
	BOOL	Flip;			//
	BOOL	Invert;			//
	BOOL	Blackmark;		//
}PRINTERINFO;


//프린터 관련 return 값
#define PRINTER_OPEN_CLOSE			0
#define PRINTER_INVALID_PARAM		1
#define PRINTER_OK					999
#define PRINTER_ERROR				1000
#define PRINTER_ERROR_POWERON		1001
#define PRINTER_ERROR_POWEROFF		1002
#define PRINTER_ERROR_SERIAL_OPEN	1010
#define PRINTER_ERROR_SERIAL_CLOSE	1011
#define PRINTER_ERROR_SERIAL_CLEAR	1012
#define PRINTER_ERROR_SERIAL_DATA	1013
#define PRINTER_ERROR_FILE_SETTING	1014
#define PRINTER_ERROR_BARCODE		1015
#define PRINTER_ERROR_BARCODE_LEN	1016		//Computed Length of barcode string is not more than 40
#define PRINTER_ERROR_PAPER			1017
#define PRINTER_ERROR_OVERHEATED	1018
#define PRINTER_UNKNOWN				1019
#define PRINTER_ERROR_LOWBATTERY	1020
#define PRINTER_ERROR_COVEROPEN		1021

//FONT 관련 
#define PRINTER_FONT				2000
#define PRINTER_FONT_NORMAL			PRINTER_FONT 
#define PRINTER_FONT_SMALL			(PRINTER_FONT + 1)
#define PRINTER_FONT_BOLD			(PRINTER_FONT + 2)
#define PRINTER_FONT_UNDERLINE		(PRINTER_FONT + 3)
#define PRINTER_FONT_DOUBLEWIDTH	(PRINTER_FONT + 4)
#define PRINTER_FONT_DOUBLEHEIGHT	(PRINTER_FONT + 5)
#define PRINTER_FONT_INVERT			(PRINTER_FONT + 6)
#define PRINTER_FONT_FLIP			(PRINTER_FONT + 7)
#define PRINTER_FONT_ROTATE			(PRINTER_FONT + 8)

//added by haru
#define PRINTER_FONT_ASCIICODE		(PRINTER_FONT + 11)
#define PRINTER_FONT_KS5601			(PRINTER_FONT + 12)
#define PRINTER_FONT_KS5601_42		(PRINTER_FONT + 12)
#define PRINTER_FONT_KS5601_32		(PRINTER_FONT + 13)
#define PRINTER_FONT_GB2312			(PRINTER_FONT + 13)
#define PRINTER_FONT_BIG5			(PRINTER_FONT + 14)


//UNDERLINE  관련 
#define PRINTER_UNDERLINE			2050
#define PRINTER_UNDERLINE_NONE		PRINTER_UNDERLINE
#define PRINTER_UNDERLINE_NORMAL	(PRINTER_UNDERLINE + 1)
#define PRINTER_UNDERLINE_THICK		(PRINTER_UNDERLINE + 2)

//ALIGN  관련 
#define PRINTER_ALIGN				2100
#define PRINTER_ALIGN_LEFT			PRINTER_ALIGN 
#define PRINTER_ALIGN_CENTER		(PRINTER_ALIGN + 1)
#define PRINTER_ALIGN_RIGHT			(PRINTER_ALIGN + 2)

//BARCODE  관련 
#define PRINTER_BARCODE				2200
#define PRINTER_BARCODE_W_UPCA		65
#define PRINTER_BARCODE_W_UPCE		66
#define PRINTER_BARCODE_W_JAN13		67
#define PRINTER_BARCODE_W_JAN8		68
#define PRINTER_BARCODE_W_CODE39	69
#define PRINTER_BARCODE_W_ITF		70
#define PRINTER_BARCODE_W_CODEBAR	71
#define PRINTER_BARCODE_W_CODE93	72
#define PRINTER_BARCODE_W_CODE128	73

#define PRINTER_BARCODE_S_UPCA		0
#define PRINTER_BARCODE_S_UPCE		1
#define PRINTER_BARCODE_S_JAN13		2
#define PRINTER_BARCODE_S_JAN8		3
#define PRINTER_BARCODE_S_CODE39	4
#define PRINTER_BARCODE_S_ITF		5
#define PRINTER_BARCODE_S_CODEBAR	6

#define PRINTER_BARCODE_WIDTH			(PRINTER_BARCODE + 10)
#define PRINTER_BARCODE_WIDTH_THIN		(PRINTER_BARCODE_WIDTH)
#define PRINTER_BARCODE_WIDTH_NORMAL	(PRINTER_BARCODE_WIDTH + 1)
#define PRINTER_BARCODE_WIDTH_THICK		(PRINTER_BARCODE_WIDTH + 2)
#define PRINTER_BARCODE_WIDTH_MORETHICK	(PRINTER_BARCODE_WIDTH + 3)
#define PRINTER_BARCODE_WIDTH_MOSTTHICK	(PRINTER_BARCODE_WIDTH + 4)
#define PRINTER_BARCODE_WIDTH_HALF		(PRINTER_BARCODE_WIDTH + 5)

#define PRINTER_BARCODE_POSITION		(PRINTER_BARCODE + 20)
#define PRINTER_BARCODE_POSITION_NORMAL	(PRINTER_BARCODE_POSITION)
#define PRINTER_BARCODE_POSITION_ABOVE	(PRINTER_BARCODE_POSITION + 1)
#define PRINTER_BARCODE_POSITION_BELOW	(PRINTER_BARCODE_POSITION + 2)
#define PRINTER_BARCODE_POSITION_BOTH	(PRINTER_BARCODE_POSITION + 3)

//이미지 관련 
#define MAX_IMAGE_SIZE				(1 * 1024 * 1024)
#define PRINTER_IMAGE				2300
#define PRINTER_IMAGE_NORMAL		PRINTER_IMAGE
#define PRINTER_IMAGE_DOUBLEWIDTH	(PRINTER_IMAGE + 1)
#define PRINTER_IMAGE_DOUBLEHEIGHT	(PRINTER_IMAGE + 2)
#define PRINTER_IMAGE_QUADRUPLE		(PRINTER_IMAGE + 3)

//Power Printer
_DLL_EXPORT_ UINT WINAPI PrinterOpen(void);
_DLL_EXPORT_ UINT WINAPI PrinterOpenNew(void);

//Power Off Printer
_DLL_EXPORT_ UINT WINAPI PrinterClose(void);
_DLL_EXPORT_ UINT WINAPI PrinterCloseNew(void);

//Printer Reset
_DLL_EXPORT_ void WINAPI PrinterReset(void);

//Printer
_DLL_EXPORT_ UINT WINAPI PrinterPrint(TCHAR *pszData);
_DLL_EXPORT_ UINT WINAPI PrinterPrint2(char *pchData);

//Set Strobe
_DLL_EXPORT_ UINT WINAPI PrinterSetStrobe(int nMode);
//Set Density
_DLL_EXPORT_ UINT WINAPI PrinterSetDensity(int nMode);

//Printer Update
_DLL_EXPORT_ UINT WINAPI PrinterTestModeShort(void);
_DLL_EXPORT_ BOOL WINAPI PrinterFirmUpdate(char *chFName);

//Line Feed
_DLL_EXPORT_ UINT WINAPI PrinterLineFeed(int nNum);

//Text Tab
_DLL_EXPORT_ UINT WINAPI PrinterTab(int nNum);

//Set Text
_DLL_EXPORT_ UINT WINAPI PrinterSetFont(int nMode, int nBold, int nHeight, int nWidth, int nUnder);

//Text Size
_DLL_EXPORT_ UINT WINAPI PrinterSetFontSize(int nWidth, int nHeight);

//Color Invert
_DLL_EXPORT_ UINT WINAPI PrinterSetInvert (int nInvert);

//Rotate Flip
_DLL_EXPORT_ UINT WINAPI PrinterSetFlip (int nFlip);	

//Rotate 90 Degree
_DLL_EXPORT_ UINT WINAPI PrinterSetRotate (int nRotate);

//Text UnderLine
_DLL_EXPORT_ UINT WINAPI PrinterSetUnderLine (int nUnder);

//Text Bold
_DLL_EXPORT_ UINT WINAPI PrinterSetBold (int nBold);

//Text Align
_DLL_EXPORT_ UINT WINAPI PrinterSetAlign(int nMode);

//Set Line Space
_DLL_EXPORT_ UINT WINAPI PrinterSetSpacingLine(int nLineNumber);

//Set Barcode Text Position
_DLL_EXPORT_ UINT WINAPI PrinterSetBarcodeText(int nVal);

//Barcode Height
_DLL_EXPORT_ UINT WINAPI PrinterSetBarCodeHeight (int nHeight);

//Barcode Width
_DLL_EXPORT_ UINT WINAPI PrinterSetBarCodeWidth (int nWidth);

//Printer Left Margin
_DLL_EXPORT_ UINT WINAPI PrinterSetLeftMargin(int nVal);

//Set Barcode
//W : System Range ( 65 ~ 73)
_DLL_EXPORT_ UINT WINAPI PrinterBarcodeW(int nSystem, int nData, TCHAR *pszBarcode);

//Set Barcode Extended
//W : System Range ( 65 ~ 73)
_DLL_EXPORT_ UINT WINAPI PrinterBarcodeWEx(int nSystem, int nData, TCHAR *pszBarcode);

//S : System Range ( 0 ~ 6)
_DLL_EXPORT_ UINT WINAPI PrinterBarcodeS(int nSystem, TCHAR *pszBarcode);

// Wait for completing printer before closing
_DLL_EXPORT_ UINT WINAPI PrinterWaitComplete();

//Close Image File
_DLL_EXPORT_ UINT WINAPI PrinterCloseImageFile();

//Load Image File
_DLL_EXPORT_ UINT WINAPI PrinterLoadImageFile(TCHAR* pszFile);
_DLL_EXPORT_ void WINAPI PrinterSetImageLeft(UINT nImageLeft);//현재 단색비트맵만 지원 가능함(2008년11월)

//Print Image
_DLL_EXPORT_ UINT WINAPI PrinterImage(int nMode);

//Get Image Name
_DLL_EXPORT_ TCHAR* PrinterGetImageName();

_DLL_EXPORT_ UINT WINAPI PrinterSetFontLang(int nMode);
_DLL_EXPORT_ UINT WINAPI PrinterSetCodeTable(int nMode);

//국가 설정 
_DLL_EXPORT_ UINT WINAPI PrinterSetInternational(int nVal);

//국가 관련 (PrinterSetInternational)
#define PRINTER_COUNTRY				0
#define PRINTER_COUNTRY_USA			PRINTER_COUNTRY
#define PRINTER_COUNTRY_FRA			PRINTER_COUNTRY+1
#define PRINTER_COUNTRY_GER			PRINTER_COUNTRY+2
#define PRINTER_COUNTRY_ENG			PRINTER_COUNTRY+3
#define PRINTER_COUNTRY_DE1			PRINTER_COUNTRY+4
#define PRINTER_COUNTRY_SWE			PRINTER_COUNTRY+5
#define PRINTER_COUNTRY_ITA			PRINTER_COUNTRY+6
#define PRINTER_COUNTRY_SPA			PRINTER_COUNTRY+7
#define PRINTER_COUNTRY_JPN			PRINTER_COUNTRY+8
#define PRINTER_COUNTRY_NOR			PRINTER_COUNTRY+9
#define PRINTER_COUNTRY_DE2			PRINTER_COUNTRY+10
#define PRINTER_COUNTRY_KOR			PRINTER_COUNTRY+11

#ifdef BLACKMARK
//Set BlackMark
_DLL_EXPORT_ UINT WINAPI PrinterSetBlackMark(int nMode);

//Black Mark Feed 
// nFeed=0: Default nFeed : 0.5mm
_DLL_EXPORT_ UINT WINAPI PrinterSkipMark(int nFeed);


#endif

_DLL_EXPORT_ UINT WINAPI PrinterTestMode();
_DLL_EXPORT_ UINT WINAPI PrinterPower(BOOL bOnOff);

#endif//_PRN_DLL_H_
