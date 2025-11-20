import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/profile/widgets/custom_card.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';

class ProfileDetailsWidget extends StatefulWidget {
  const ProfileDetailsWidget({super.key});

  @override
  State<ProfileDetailsWidget> createState() => _ProfileDetailsWidgetState();
}

class _ProfileDetailsWidgetState extends State<ProfileDetailsWidget> {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        CustomCard(
          title: context.translate(LangKeys.nationality),
          subtitle: context.translate(LangKeys.egyptian),
          iconPath: Assets.imagesUser,
        ),
        CustomCard(
          title: context.translate(LangKeys.times),
          subtitle: context.translate(LangKeys.timeRange),
          iconPath: Assets.imagesTimer,
        ),
        CustomCard(
          title: context.translate(LangKeys.phone),
          subtitle: context.translate(LangKeys.phoneNumber),
          iconPath: Assets.imagesCall,
        ),
        CustomCard(
          title: context.translate(LangKeys.salary),
          subtitle: context.translate(LangKeys.salaryValue),
          iconPath: Assets.imagesMoneys,
        ),
        CustomCard(
          title: context.translate(LangKeys.jobTitle),
          subtitle: context.translate(LangKeys.flutterDeveloper),
          iconPath: Assets.imagesCase,
        ),
        CustomCard(
          title: context.translate(LangKeys.workLocation),
          subtitle: context.translate(LangKeys.riyadhOffice),
          iconPath: Assets.imagesLocation,
        ),
        CustomCard(
          title: context.translate(LangKeys.attachments),
          subtitle: context.translate(LangKeys.attachmentsCount),
          iconPath: Assets.imagesFiles,
          subtitleIcon: Assets.imagesPdf,
          subtitleAltColor: MyColors.black,
          endIcon: Assets.imagesDownload,
        ),
      ],
    );
  }
}
