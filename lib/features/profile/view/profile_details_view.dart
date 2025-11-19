import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/profile/widgets/custom_card.dart';
import 'package:athr_hr/features/profile/widgets/custom_profile_data.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ProfileDetailsView extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;

  const ProfileDetailsView({super.key, this.onChangeTab});

  @override
  State<ProfileDetailsView> createState() => _ProfileDetailsViewState();
}

class _ProfileDetailsViewState extends State<ProfileDetailsView> {

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: MyColors.white,
        body: SingleChildScrollView(
          child: Column(
            children: [
              Padding(
                padding: EdgeInsets.all(16.sp),
                child: CustomAppBarRow(
                  title: context.translate(LangKeys.personalData),
                  trailing: Image.asset(
                    Assets.imagesArrow,
                    width: 24.w,
                    height: 24.h,
                    fit: BoxFit.contain,
                  ),
                  onPressed: (){
                    widget.onChangeTab?.call(4);
                  },
                ),
              ),
              SizedBox(height: 32.h),
              CustomProfileData(
                imageUrl: Assets.imagesProfile,
                name: context.translate(LangKeys.name),
                jobDescription: context.translate(LangKeys.job),
                id: context.translate(LangKeys.id),
                prefix: context.translate(LangKeys.prefix),
              ),
              CustomCard(title: context.translate(LangKeys.nationality),
                subtitle: context.translate(LangKeys.egyptian) ,
                iconPath: Assets.imagesUser,),
              CustomCard(title: context.translate(LangKeys.times),
                subtitle: context.translate(LangKeys.timeRange) ,
                iconPath: Assets.imagesTimer,),
              CustomCard(title: context.translate(LangKeys.phone),
                subtitle: context.translate(LangKeys.phoneNumber) ,
                iconPath: Assets.imagesCall,),
              CustomCard(title: context.translate(LangKeys.salary),
                subtitle: context.translate(LangKeys.salaryValue) ,
                iconPath: Assets.imagesMoneys,),
              CustomCard(title: context.translate(LangKeys.jobTitle),
                subtitle: context.translate(LangKeys.flutterDeveloper) ,
                iconPath: Assets.imagesCase,),
              CustomCard(title: context.translate(LangKeys.workLocation),
                subtitle: context.translate(LangKeys.riyadhOffice) ,
                iconPath: Assets.imagesLocation,),
              CustomCard(title: context.translate(LangKeys.attachments),
                subtitle: context.translate(LangKeys.attachmentsCount) ,
                iconPath: Assets.imagesFiles,
                subtitleIcon: Assets.imagesPdf,
                subtitleAltColor: MyColors.black,
                endIcon: Assets.imagesDownload,
              ),
              SizedBox(height: 30.h,),
            ],
          ),
        ),
      ),
    );
  }
}
