﻿Feature: BasicTests

Basic Test the App 

@tag1
Scenario: App successfully starts
	Then the home page is loaded


Scenario: NavMenu is correctly rendered
	Then the navigation contains 3 items


Scenario: Earnings page is correctly rendered
	Given The user is on the earning overview
	Then the page title is Earnings
