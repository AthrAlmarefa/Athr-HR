import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/on_boarding/on_boarding_card.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';

class OnBoarding extends StatefulWidget {
  const OnBoarding({super.key});

  @override
  State<OnBoarding> createState() => _OnBoardingState();
}

class _OnBoardingState extends State<OnBoarding> {
  final PageController _controller = PageController();
  int currentPage = 0;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: PageView(
        controller: _controller,
        onPageChanged: (index) {
          setState(() {
            currentPage = index;
          });
        },
        children: [
          CustomOnboardingScreen(
            title: context.translate(LangKeys.hello),
            subtitle:  context.translate(LangKeys.trackAndOrganizeWork),
            imageAsset: Assets.imagesOnBoarding1,
            buttonText:context.translate(LangKeys.startNow) ,
            onButtonPressed: () {
              _controller.animateToPage(
                1,
                duration: const Duration(milliseconds: 300),
                curve: Curves.easeInOut,
              );
            },
            currentIndex: currentPage,
          ),
          CustomOnboardingScreen(
            title: context.translate(LangKeys.monthlyActivity),
            subtitle:context.translate(LangKeys.monthlyPerformanceReport),
            imageAsset: Assets.imagesOnBoarding2,
            buttonText: context.translate(LangKeys.startNow),
            onButtonPressed: () {
              _controller.animateToPage(
                2,
                duration: const Duration(milliseconds: 300),
                curve: Curves.easeInOut,
              );
            },
            currentIndex: currentPage,
          ),
          CustomOnboardingScreen(
            title: context.translate(LangKeys.manageLeaves),
            subtitle:context.translate(LangKeys.leaveAndAdminTasks),
            imageAsset: Assets.imagesOnBoarding3,
            buttonText: context.translate(LangKeys.startNow),
            onButtonPressed: () {
             Navigator.pushNamed(context, AppRoutes.login);
            },
            currentIndex: currentPage,
          ),
          DotsIndicator(currentIndex: currentPage, totalDots: 3),
        ],
      ),
    );
  }
}
