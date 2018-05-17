// Prn_Borna.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#ifdef STANDARDSHELL_UI_MODEL
#include "resource.h"
#endif

// CPrn_BornaApp:
// See Prn_Borna.cpp for the implementation of this class
//

class CPrn_BornaApp : public CWinApp
{
public:
	CPrn_BornaApp();
	
// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CPrn_BornaApp theApp;
