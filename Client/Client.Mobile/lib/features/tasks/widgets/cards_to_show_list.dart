import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:athr_hr/features/tasks/widgets/build_progress_card.dart';

class TaskCardsHelper {
  static List<Widget> cardsToShow({
    required BuildContext context,
    required int selectedTabIndex,
    required int progressInProgress,
    required int progressInComplete,
    required ValueChanged<int> onProgressInProgressChanged,
    required ValueChanged<int> onProgressInCompleteChanged,
  }) {
    if (selectedTabIndex == 0) {
      return [
        BuildProgressCard(
          title: context.translate(LangKeys.authenticationUnit),
          subtitle: context.translate(LangKeys.oauthIntegration),
          progress: progressInProgress,
          mainImagePath: Assets.imagesImplementationicon,
          userImagePath: Assets.imagesUserCircle,
          calendarImagePath: Assets.imagesTaskscalender,
          date: context.translate(LangKeys.date20251115),
          onProgressChanged: onProgressInProgressChanged,
          assignedBy: context.translate(LangKeys.assignedBy),
          userName: context.translate(LangKeys.abdullahMohamed),
        ),
        BuildProgressCard(
          title: context.translate(LangKeys.authenticationUnit),
          subtitle: context.translate(LangKeys.oauthIntegration),
          progress: progressInComplete,
          mainImagePath: Assets.imagesCompleted,
          userImagePath: Assets.imagesUserCircle,
          calendarImagePath: Assets.imagesTaskscalender,
          date: context.translate(LangKeys.date20251115),
          onProgressChanged: onProgressInCompleteChanged,
          assignedBy: context.translate(LangKeys.assignedBy),
          userName: context.translate(LangKeys.abdullahMohamed),
        ),
      ];
    } else if (selectedTabIndex == 1) {
      return [
        BuildProgressCard(
          title: context.translate(LangKeys.authenticationUnit),
          subtitle: context.translate(LangKeys.oauthIntegration),
          progress: progressInProgress,
          mainImagePath: Assets.imagesImplementationicon,
          userImagePath: Assets.imagesUserCircle,
          calendarImagePath: Assets.imagesTaskscalender,
          date: context.translate(LangKeys.date20251115),
          onProgressChanged: onProgressInProgressChanged,
          assignedBy: context.translate(LangKeys.assignedBy),
          userName: context.translate(LangKeys.abdullahMohamed),
        ),
      ];
    } else {
      return [
        BuildProgressCard(
          title: context.translate(LangKeys.authenticationUnit),
          subtitle: context.translate(LangKeys.oauthIntegration),
          progress: progressInComplete,
          mainImagePath: Assets.imagesCompleted,
          userImagePath: Assets.imagesUserCircle,
          calendarImagePath: Assets.imagesTaskscalender,
          date: context.translate(LangKeys.date20251115),
          onProgressChanged: onProgressInCompleteChanged,
          assignedBy: context.translate(LangKeys.assignedBy),
          userName: context.translate(LangKeys.abdullahMohamed),
        ),
      ];
    }
  }
}
