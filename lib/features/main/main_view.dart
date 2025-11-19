import 'package:athr_hr/core/widgets/custom_navigation_bar.dart';
import 'package:athr_hr/features/auth/change_password/view/change_password_view.dart';
import 'package:athr_hr/features/home/home_view.dart';
import 'package:athr_hr/features/leaves/view/leaves_view.dart';
import 'package:athr_hr/features/profile/view/profile_details_view.dart';
import 'package:athr_hr/features/profile/view/profile_view.dart';
import 'package:athr_hr/features/tasks/view/tasks_view.dart';
import 'package:athr_hr/features/times/view/time_view.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';

class MainScreen extends StatefulWidget {
  const MainScreen({super.key});

  @override
  State<MainScreen> createState() => _MainScreenState();
}
class _MainScreenState extends State<MainScreen> {
  int currentIndex = 0;

  final List<String> activeIcons = [
    Assets.imagesSelectedhome,
    Assets.imagesSelectedclock,
    Assets.imagesSelectednote,
    Assets.imagesSelectedcalendar,
    Assets.imagesAccount
  ];

  final List<String> inactiveIcons = [
    Assets.imagesHome,
    Assets.imagesClock,
    Assets.imagesNote,
    Assets.imagesCalendar,
    Assets.imagesNotselecteprofile
  ];

  late final List<Widget> screens = [
    HomeView(),
    TimeView(),
    TasksView(),
    LeavesView(),
    ProfileView(
      onChangeTab: (index) {
        setState(() {
          currentIndex = index;
        });
      },
    ),
    ChangePasswordView(
      onChangeTab: (index) {
        setState(() {
          currentIndex = index;
        });
      },
    ),
    ProfileDetailsView(
      onChangeTab: (index) {
        setState(() {
          currentIndex = index;
        });
      },
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: IndexedStack(
        index: currentIndex,
        children: screens,
      ),
      bottomNavigationBar: CustomBottomNavBar(
        currentIndex: currentIndex,
        activeIcons: activeIcons,
        inactiveIcons: inactiveIcons,
        onTap: (index) {
          setState(() {
            currentIndex = index;
          });
        },
      ),
    );
  }
}
