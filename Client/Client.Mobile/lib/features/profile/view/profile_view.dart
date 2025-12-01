import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/profile/widgets/profile_widget.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ProfileView extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;
  const ProfileView({super.key, this.onChangeTab});

  @override
  State<ProfileView> createState() => _ProfileViewState();
}

class _ProfileViewState extends State<ProfileView> {
  int currentIndex = 0;
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: MyColors.white,
        body: Column(
          children: [
            Container(
              padding: EdgeInsets.all(16.sp),
              child: CustomAppBarRow(
                title: context.translate(LangKeys.profile),
                trailing: Image.asset(
                  Assets.imagesArrow,
                  width: 24.w,
                  height: 24.h,
                  fit: BoxFit.contain,
                ),
              ),
            ),
            ProfileWidget(onChangeTab: widget.onChangeTab,),
          ],
        ),
      ),
    );
  }
}
